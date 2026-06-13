---
title: 시스템 요구 사항
type: docs
weight: 60
url: /ko/python-net/system-requirements/
keywords:
  - 시스템 요구 사항
  - 운영 체제
  - 설치
  - 종속성
  - Windows
  - Linux
  - macOS
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET 시스템 요구 사항을 확인하십시오. Windows, Linux 및 macOS에서 PowerPoint와 OpenDocument 지원을 원활하게 보장합니다."
---
## **소개**

Aspose.Slides for Python via .NET는 Microsoft PowerPoint와 같은 타사 제품을 설치할 필요가 없습니다. Aspose.Slides는 Microsoft PowerPoint 프레젠테이션 형식을 포함한 다양한 형식의 문서를 생성, 수정, 변환 및 렌더링하는 엔진입니다.

## **지원되는 운영 체제**

Aspose.Slides for Python은 Windows(32비트 및 64비트), macOS 및 Python 3.5 이상이 설치된 시스템에서 64비트 Linux를 지원합니다.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">운영 체제</td>
        <td style="font-weight: bold; width:400px">버전</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>및 기타</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **대상 Linux 및 macOS 플랫폼에 대한 시스템 요구 사항**

- GCC 6 런타임 라이브러리(또는 이후 버전).
- [libgdiplus](https://github.com/mono/libgdiplus), GDI+ API의 오픈 소스 구현.
- .NET Core Runtime의 종속성. .NET Core Runtime 자체를 설치할 필요는 없습니다.
- Python 3.5–3.7의 경우: `pymalloc` 빌드의 Python이 필요합니다. `--with-pymalloc` 빌드 옵션은 기본적으로 활성화됩니다. 일반적으로 `pymalloc` 빌드의 Python은 파일 이름에 `m` 접미사가 붙습니다.
- `libpython` 공유 라이브러리. `--enable-shared` Python 빌드 옵션은 기본적으로 비활성화되어 있으며, 일부 Python 배포판에는 `libpython` 공유 라이브러리가 포함되어 있지 않습니다. 일부 Linux 플랫폼에서는 패키지 관리자(예: `sudo apt-get install libpython3.7`)를 사용하여 `libpython` 공유 라이브러리를 설치할 수 있습니다. 일반적인 문제는 `libpython` 라이브러리가 공유 라이브러리의 비표준 위치에 설치되는 것입니다. Python을 컴파일할 때 Python 빌드 옵션을 사용해 대체 라이브러리 경로를 지정하거나, 시스템 표준 공유 라이브러리 위치에 `libpython` 라이브러리 파일에 대한 심볼릭 링크를 생성하여 해결할 수 있습니다. 일반적으로 `libpython` 공유 라이브러리 파일 이름은 Python 3.5–3.7의 경우 `libpythonX.Ym.so.1.0`, Python 3.8 이상에서는 `libpythonX.Y.so.1.0` 형식입니다(예: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Microsoft PowerPoint가 설치되어야 변환 및 렌더링이 가능합니까?**

아니요, PowerPoint는 필요하지 않습니다; Aspose.Slides는 독립형 엔진으로 [생성](/slides/ko/python-net/create-presentation/), 수정, [변환](/slides/ko/python-net/convert-presentation/), 및 [렌더링](/slides/ko/python-net/convert-powerpoint-to-png/)을 수행할 수 있습니다.

**특정 .NET 버전(Core/5+/6+)이 머신에 필요합니까?**

`.NET Runtime` 자체를 설치할 필요는 없지만, 해당 종속성은 Linux/macOS에 존재해야 합니다. 이는 런타임을 완전히 설치하지 않고도 일반적으로 .NET 종속성으로 설치되는 패키지들을 시스템에 포함시켜야 함을 의미합니다.

**올바른 렌더링을 위해 필요한 글꼴은 무엇입니까?**

실제로 프레젠테이션에 사용된 글꼴이나 적절한 [대체 글꼴](/slides/ko/python-net/font-substitution/)이 존재해야 합니다. Linux/macOS에서 일관된 렌더링을 보장하려면 일반적인 글꼴 패키지를 설치하는 것이 좋습니다.

**Linux에서 사용자 정의 글꼴이 대체 글꼴이나 누락된 텍스트로 표시되는 이유는 무엇입니까?**

글꼴 파일에 일관성 없는 또는 손상된 name-table 항목이 있는 경우, Linux 글꼴 매칭 스택(FreeType/fontconfig)이 잘못된 레코드를 선택하여 글꼴을 찾지 못하게 될 수 있습니다. name-table 레코드가 수정된 글꼴 버전을 사용하거나 일관된 대체 글꼴을 설치하면 문제가 해결됩니다.