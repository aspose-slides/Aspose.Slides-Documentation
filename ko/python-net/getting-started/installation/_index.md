---
title: 설치
type: docs
weight: 70
url: /ko/python-net/installation/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 사용
- Aspose.Slides 설치
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Windows, Linux 및 macOS에서 pip를 사용하여 PyPI에서 .NET을 통한 Python용 Aspose.Slides를 설치하고, Linux와 macOS에 필요한 네이티브 라이브러리를 설치합니다."
---
## **개요**

이 문서에서는 Windows, Linux 및 macOS에서 .NET을 통한 Python용 Aspose.Slides를 설치하는 방법을 설명합니다. 이 패키지는 [PyPI](https://pypi.org/project/aspose.slides/)에 게시되며 pip를 사용해 설치합니다. 사용되는 .NET 런타임이 포함되어 있으므로 별도로 .NET을 설치할 필요가 없습니다. Linux 및 macOS에서는 해당 런타임이 운영 체제에 포함되지 않을 수 있는 네이티브 라이브러리를 필요로 합니다; 아래 섹션에서 해당 라이브러리를 소개합니다.

Aspose.Slides for Python via .NET는 Python 3.5부터 3.14까지 지원합니다. PyPI는 Windows(32비트 및 64비트), Linux(x86_64 및 ARM64), macOS(Intel 및 Apple silicon)용 패키지를 제공합니다.

## **Windows**

Windows에서는 pip를 사용해 패키지를 설치합니다. 다른 라이브러리는 필요하지 않습니다.

```bash
pip install aspose.slides
```

## **Linux**

Linux에서는 패키지에 포함된 .NET 런타임이 두 개의 라이브러리를 필요로 합니다:

- **libgdiplus**, Windows GDI+ 그래픽 API의 구현입니다. 이를 설치하지 않으면 프레젠테이션 저장 시 `The type initializer for 'Gdip' threw an exception` 오류가 발생합니다.
- **ICU** (International Components for Unicode). 이를 설치하지 않으면 첫 번째 Aspose.Slides 호출 시 Python 프로세스가 `Couldn't find a valid ICU package installed on the system` 메시지와 함께 종료됩니다.

Debian 및 Ubuntu에서는 apt를 사용해 두 라이브러리를 모두 설치합니다:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

ICU 패키지 이름에는 버전이 포함됩니다: Debian 13에서는 `libicu76`이 해당 패키지이며, Debian 12에서는 대신 `libicu72`를, Ubuntu 24.04에서는 `libicu74`를 설치합니다. 시스템에서 정확한 이름을 확인하려면 다음 명령을 실행하세요:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

그런 다음 패키지를 가상 환경에 설치합니다. 최신 Debian 및 Ubuntu 릴리스에서는 시스템 Python이 가상 환경 외부에서 `pip install`을 허용하지 않으며, `externally-managed-environment` 오류와 함께 중단됩니다.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

스크립트를 실행할 때는 동일한 가상 환경을 활성화한 상태에서 실행하십시오. 배포판이 관리하지 않는 Python(예: 공식 `python` Docker 이미지에 포함된 Python)을 사용하는 경우 가상 환경 없이도 `pip install aspose.slides`를 실행할 수 있습니다.

프레젠테이션에서 사용된 글꼴 또는 적절한 대체 글꼴이 시스템에 설치되어 있어야 슬라이드를 PDF나 이미지로 변환할 때 텍스트가 올바르게 렌더링됩니다.

## **macOS**

macOS에서의 설치는 아직 검증되지 않았습니다. macOS에서 Aspose.Slides를 사용하려면 다음 사전 요구사항이 필요합니다:

- **Python with shared libraries**, 즉 `--enable-shared` 구성 옵션으로 빌드된 Python입니다. [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos)로 Python을 설치하는 경우, Python 버전을 설치할 때 `PYTHON_CONFIGURE_OPTS` 환경 변수를 `--enable-shared` 로 설정하십시오.
- **시스템 라이브러리 디렉터리에 libpython 라이브러리**. pyenv로 설치한 Python은 *~/.pyenv/versions* 아래에 *libpython3.9.dylib*와 같은 libpython 라이브러리를 보관합니다; 이를 */usr/local/lib*에 심볼릭 링크로 연결하십시오.
- **libgdiplus**, Windows GDI+ 그래픽 API의 구현입니다. Homebrew에서는 `mono-libgdiplus` 패키지로 제공됩니다.

그런 다음 pip를 사용해 패키지를 설치합니다.

## **설치 확인**

설치를 확인하려면 [Create Presentations](/slides/ko/python-net/create-presentation/)에 있는 첫 번째 예제를 *hello.py* 파일로 저장하고 `python hello.py`를 실행하십시오. 그러면 현재 폴더에 *new_presentation.pptx*가 저장됩니다.

## **업그레이드**

기존 설치를 최신 버전으로 업그레이드하려면 패키지를 설치한 환경에서 다음 명령을 실행하십시오:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**가상 환경에 Aspose.Slides를 설치할 수 있나요?**

예. pip를 사용해 모든 Python 가상 환경에 설치할 수 있습니다. Linux 및 macOS에서 필요한 네이티브 라이브러리는 시스템에 설치되며 가상 환경 내부에 설치되지 않습니다.

**Docker 컨테이너에서 Aspose.Slides를 사용할 수 있나요?**

예. 이미지에는 Linux 시스템과 동일한 네이티브 라이브러리인 libgdiplus와 ICU, 그리고 프레젠테이션에서 사용하는 글꼴이 포함되어야 합니다.

**무료 버전이나 체험판 제한이 있나요?**

예. 라이선스가 없을 경우 Aspose.Slides는 평가 모드로 실행되며, 저장되는 모든 슬라이드에 평가 워터마크를 추가하고 프레젠테이션에서 읽은 텍스트를 잘라냅니다. 이러한 제한을 해제하려면 유효한 [license](/slides/ko/python-net/licensing/)를 적용하십시오.