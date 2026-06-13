---
title: 시스템 요구 사항
type: docs
weight: 80
url: /ko/java/system-requirements/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 시스템 요구 사항을 확인하세요. Windows, Linux 및 macOS에서 PowerPoint 및 OpenDocument 지원을 원활하게 보장합니다."
---
## **개요**
Aspose.Slides for Java는 Microsoft PowerPoint를 설치할 필요가 없습니다. Aspose.Slides 자체가 Microsoft PowerPoint 문서 생성, 변환, 페이지 레이아웃 및 렌더링 엔진이기 때문입니다.
## **지원되는 운영 체제**
Aspose.Slides for Java는 Java 런타임을 실행하는 32비트 또는 64비트 운영 체제를 모두 지원합니다(아래에 제한되지 않음).
### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)


### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS 등)

### **Mac**
- Mac OS X

## **지원되는 Java 버전**
Aspose.Slides for Java는 J2SE 6.0(Java 1.6) 이상을 지원합니다.

## **FAQ**

**변환 및 렌더링에 Microsoft PowerPoint가 설치되어 있어야 합니까?**

아니요, PowerPoint는 필요하지 않습니다; Aspose.Slides는 프레젠테이션을 [생성](/slides/ko/java/create-presentation/), 수정, [변환](/slides/ko/java/convert-presentation/), 및 [렌더링](/slides/ko/java/convert-powerpoint-to-png/)하기 위한 독립형 엔진입니다.

**올바른 렌더링을 위해 어떤 글꼴이 필요합니까?**

실제로 프레젠테이션에 사용된 글꼴 또는 적절한 [대체 글꼴](/slides/ko/java/font-substitution/)이 설치되어 있어야 합니다. Linux/macOS에서 일관된 렌더링을 보장하려면 일반적인 글꼴 패키지를 설치하는 것이 좋습니다.

**Linux에서 사용자 지정 글꼴이 대체 글꼴 또는 누락된 텍스트로 렌더링되는 이유는 무엇입니까?**

글꼴 파일에 일관성 없거나 손상된 name-table 항목이 있는 경우, Linux의 글꼴 매칭 스택(FreeType/fontconfig)이 잘못된 레코드를 선택하여 글꼴을 찾지 못할 수 있습니다. name-table 항목이 수정된 글꼴 버전을 사용하거나 일관된 대체 글꼴을 설치하면 문제가 해결됩니다.