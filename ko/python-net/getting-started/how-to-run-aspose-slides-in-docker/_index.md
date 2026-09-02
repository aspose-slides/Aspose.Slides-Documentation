---
title: Docker에서 Aspose.Slides 실행 방법
linktitle: Docker에서 Aspose.Slides
type: docs
weight: 150
url: /ko/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker에서 Aspose.Slides
- Docker 컨테이너
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- 폰트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Docker에서 .NET 기반 Python용 Aspose.Slides 실행: 작동하는 Dockerfile, 패키지가 필요한 네이티브 라이브러리, 폰트 설정 및 컨테이너 내부 라이선스 관리."
---
## **개요**

Aspose.Slides for Python via .NET는 Linux 컨테이너에서 실행되지만, 이 패키지는 번들된 .NET Core 3.1 런타임을 감싸는 Python 래퍼입니다. 해당 런타임은 슬림 Python 이미지에 포함되지 않은 세 개의 네이티브 라이브러리가 필요하며, 버전에 매우 민감합니다. 이 문서에서는 작동하는 Dockerfile을 제공하고, 각 종속성이 왜 필요한지 설명하며, 폰트와 라이선스를 추가하는 방법을 보여줍니다.

## **작동하는 Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

빌드 및 실행:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **베이스 이미지가 Debian 11인 이유**

`aspose.slides` 휠은 **.NET Core 3.1** 런타임을 번들링하며, 이 런타임은 현재 Debian 릴리즈에 포함된 라이브러리 버전보다 오래되었습니다. Debian 12와 13에서는 컨테이너가 성공적으로 빌드되지만 첫 번째 `Presentation()` 호출 시 실패합니다:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

메시지는 오해의 소지가 있습니다 — ICU는 해당 이미지에 설치되어 있지만 ICU 72 또는 76 버전이며, .NET Core 3.1은 오래된 주요 버전만 인식합니다. Debian 12는 추가로 OpenSSL 3을 제공하는데, 이는 두 번째 오류를 발생시킵니다:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye`는 Debian 11이며, 번들된 런타임이 기대하는 두 버전을 모두 제공합니다:

| Package | Version on Debian 11 | Why it is needed |
|---|---|---|
| `libgdiplus` | 6.0.4 | 모양, 텍스트 및 이미지를 렌더링하는 데 사용되는 GDI+ 구현 |
| `libicu67` | 67.1 | 글로벌화 데이터. 최신 주요 버전은 .NET Core 3.1에서 인식되지 않음 |
| `libssl1.1` | 1.1.1w | 암호화. Debian 11에 사전 설치되어 있으나 Debian 12 이상에는 없음 |
| `libfontconfig1` | — | 폰트 검색 |

`libssl1.1`은 이미 베이스 이미지에 포함되어 있으므로 `apt-get install`에 명시할 필요가 없습니다.

새로운 베이스 이미지를 사용해야 한다면 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1`을 설정하여 ICU 요구사항을 우회할 수 있습니다. 이는 문화권별 형식을 비활성화하지만 OpenSSL 문제는 해결되지 않으므로, Debian 11이 여전히 더 간단한 선택입니다.

## **폰트**

슬림 이미지에는 폰트가 전혀 포함되지 않습니다. 최소 하나의 폰트라도 설치되지 않으면 PDF, 이미지, HTML 출력에서 텍스트가 빈 상자처럼 표시됩니다. `fonts-dejavu-core`는 작고 일반적인 시작점입니다.

프레젠테이션의 의도된 모양과 일치하도록 사용되는 폰트를 이미지에 복사하고 Aspose.Slides에 지정하십시오:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **컨테이너 내부 라이선스**

라이선스 파일을 이미지에 포함해서는 안 됩니다 — 이미지를 가져오는 모든 사람이 라이선스를 얻게 됩니다. 런타임에 마운트하십시오:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

라이선스가 없으면 라이브러리가 평가 모드로 실행되어 워터마크가 추가되고 처리 가능한 슬라이드 수가 제한됩니다. 자세한 내용은 [라이선스](/slides/ko/python-net/licensing/)를 참조하십시오.

## **메모리**

PDF나 이미지로 렌더링하는 것은 파일을 읽는 것보다 메모리를 더 많이 사용합니다. 메모리 제한이 엄격한 컨테이너는 변환 중간에 OOM 킬러에 의해 종료될 수 있으며, 이 경우 일반적으로 파이썬 스택 트레이스 없이 프로세스가 사라지는 현상이 나타납니다. 이런 일이 발생하면 코드를 조사하기 전에 컨테이너의 메모리 제한을 늘리세요.