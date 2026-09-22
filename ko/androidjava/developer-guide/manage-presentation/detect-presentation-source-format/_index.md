---
title: Android에서 원본 프레젠테이션 형식 결정
linktitle: 소스 형식
type: docs
weight: 35
url: /ko/androidjava/detect-presentation-source-format/
keywords:
- 소스 형식
- 프레젠테이션 형식 감지
- PowerPoint
- OpenDocument
- 프레젠테이션
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 로드된 프레젠테이션의 원본 형식을 읽고, 감지 API를 비교하며, 파일, 스트림 및 레거시 형식을 처리합니다."
---
## **개요**

프레젠테이션을 로드한 후에는 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSourceFormat--) 메서드를 호출하여 원래 형식을 확인합니다. 이 메서드는 [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--)에서도 사용할 수 있습니다. 현재 인스턴스가 로드된 형식에 따라 후속 처리가 달라지는 경우에 사용하십시오.

소스 형식은 출력 파일에 대해 선택된 [SaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/)과는 별개입니다. 다른 형식으로 저장한다고 기존 인스턴스의 소스 형식이 바뀌지는 않습니다.

예제는 Java와 파일 경로를 사용합니다. Android에서는 샘플 경로를 앱이 접근 가능한 저장소(예: 앱의 내부 파일 디렉터리) 경로로 교체하십시오.

## **파일의 소스 형식 읽기**

이 예제는 기존 `sample.pptx` 파일이 필요합니다. 파일을 로드하고 파일 이름이 아니라 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSourceFormat--)을 사용해 애플리케이션 처리 정책을 선택합니다. 입력 경로를 변경하면 다른 형식을 시험해 볼 수 있습니다. 예제는 선택된 정책을 출력합니다; 메시지는 애플리케이션 로직에 맞게 교체하십시오.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **지원되는 값 인식**

[SourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sourceformat/) 클래스는 다음 프레젠테이션 형식을 구분하는 정수 상수를 정의합니다. 아래 확장자는 원본 파일 이름을 재구성한 것이 아니라 관례적인 확장자입니다.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 프레젠테이션 |
| `Pptx` | `.pptx` | Office Open XML 프레젠테이션 |
| `Pptm` | `.pptm` | 매크로 사용 Office Open XML 프레젠테이션 |
| `Pps` | `.pps` | PowerPoint 97–2003 슬라이드 쇼 |
| `Ppsx` | `.ppsx` | Office Open XML 슬라이드 쇼 |
| `Ppsm` | `.ppsm` | 매크로 사용 Office Open XML 슬라이드 쇼 |
| `Pot` | `.pot` | PowerPoint 97–2003 템플릿 |
| `Potx` | `.potx` | Office Open XML 템플릿 |
| `Potm` | `.potm` | 매크로 사용 Office Open XML 템플릿 |
| `Odp` | `.odp` | OpenDocument 프레젠테이션 |
| `Otp` | `.otp` | OpenDocument 프레젠테이션 템플릿 |
| `Fodp` | `.fodp` | Flat XML ODF 프레젠테이션 |
| `Xml` | `.xml` | PowerPoint XML 프레젠테이션 |

## **스트림의 소스 형식 읽기**

이 예제는 기존 `sample.pps` 파일이 필요합니다. 파일의 바이트를 메모리 스트림에 읽어 들이면 파일 이름이 없는 입력(예: 데이터베이스 값 또는 업로드된 바이트 배열)을 모델링할 수 있습니다. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 생성자는 스트림만 받습니다.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS, POT는 동일한 기본 이진 형식을 사용합니다. 파일 경로로 로드할 경우 확장자를 통해 슬라이드 쇼나 템플릿을 구별할 수 있습니다. 파일 이름이 없으면 레거시 PPS와 POT 콘텐츠가 `SourceFormat.Ppt` 로 보고될 수 있으며, 위의 PPS 예제는 `SourceFormat.Ppt` 정수 값을 출력합니다.

애플리케이션에서 이러한 구분을 유지해야 한다면 원본 파일 이름이나 서브타입 메타데이터를 별도로 보관하십시오. 확장자는 레거시 서브타입에 유용한 힌트가 될 수 있지만 임의의 프레젠테이션 콘텐츠를 식별하는 유일한 근거가 되어서는 안 됩니다.

## **로드 전후 감지 비교**

파일을 완전한 프레젠테이션 객체 모델로 로드하기 전에 검사하려면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)와 [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--)를 사용하십시오. 인스턴스가 이미 존재한다면 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSourceFormat--)을 사용합니다.

이 예제는 `sample.pptx`가 필요하며, `LoadFormat.Pptx`와 `SourceFormat.Pptx`의 정수 값을 각각 출력합니다. 실제 환경에서는 처리 단계에 맞는 API를 선택하십시오; 이미 로드된 프레젠테이션에 대해 소스 형식을 얻기 위해 두 번째 검사를 수행할 필요는 없습니다.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

결과는 서로 다른 클래스의 상수를 사용합니다: [LoadFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/loadformat/)와 [SourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sourceformat/). 숫자 값을 직접 비교하거나 모든 형식이 동일한 감지 결과를 가진다고 가정하지 마십시오. PowerPoint XML은 로드 전에는 `LoadFormat.Unknown`으로, 로드 후에는 `SourceFormat.Xml`으로 보고될 수 있습니다.

## **소스 형식과 출력 형식 분리 유지**

이 예제는 `sample.pptx`를 필요로 하며 `converted.odp` 파일을 씁니다. 원본 인스턴스를 저장하기 전후에 `SourceFormat.Pptx` 정수 값을 출력합니다. ODP 출력에서 새로 로드된 인스턴스만 `Odp` 를 보고합니다.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

`new Presentation()`으로 처음부터 만든 프레젠테이션은 `SourceFormat.Pptx` 를 보고합니다. 입력 파일이 없기 때문에 이는 새로 만든 인스턴스의 기본값일 뿐, PPTX 파일이 로드된 증거는 아닙니다. 구분이 중요한 경우 애플리케이션에서 생성 여부와 로드 여부를 별도로 추적하십시오.

## **소스 형식을 확장자로 매핑**

다음 예제는 `sample.pptx`가 필요합니다. 현재 지원되는 모든 [SourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sourceformat/) 값을 관례적인 확장자로 매핑하며, 입력 파일 이름을 파싱하지 않습니다. 인식되지 않은 값에 대해서는 확장자를 조용히 할당하지 않도록 기본값을 사용합니다.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

이 매핑은 파일을 변환하거나 스트림 로드 중에 손실된 레거시 PPS/POT 서브타입을 복구하지 않습니다. 실제 저장 시에는 [SaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/)을 명시적으로 선택하거나 [원본 형식으로 프레젠테이션 저장](/slides/ko/androidjava/save-presentation/#save-presentations-in-their-original-format)에서 보여준 변환을 사용하십시오.

## **저장 후 다시 열어 형식 확인**

이 자체 포함 예제는 프레젠테이션을 만들고 작업 디렉터리에 세 파일을 작성합니다(동일 이름 파일이 있으면 덮어씀). 각 출력 파일을 경로와 메모리 스트림을 통해 다시 엽니다. PPTX와 ODP는 두 경로 모두 저장된 형식을 보고합니다. PPS는 경로로 로드하면 `Pps`를, 파일 이름 없이 같은 바이트를 로드하면 `Ppt`를 보고합니다.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

다음 표는 확장자가 일치하는 프레젠테이션에 대한 소스 형식 식별을 요약합니다. 이름은 상수를 나타내며, Java 예제는 해당 정수 값을 출력합니다:

| Saved format | SourceFormat from a file path | SourceFormat from a nameless stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 콘텐츠는 파일 이름이 없는 스트림에서 `Ppt` 로 식별됩니다. 이 표는 형식 식별 결과를 설명하는 것이며, 변환 과정에서 모든 프레젠테이션 기능이 보존된다는 의미는 아닙니다.

## **FAQ**

**ODP 로 저장하면 PPTX에서 로드한 프레젠테이션의 소스 형식이 바뀝니까?**

아니요. 기존 인스턴스는 여전히 `Pptx` 를 보고합니다. 저장된 ODP 파일에서 로드한 인스턴스는 `Odp` 를 보고합니다.

**스트림만으로 레거시 프레젠테이션, 슬라이드 쇼, 템플릿을 항상 구분할 수 있습니까?**

아니요. PPT, PPS, POT는 동일한 이진 형식을 공유합니다. 구분이 필요하면 파일 이름이나 서브타입 메타데이터를 별도로 보관하십시오.

**프레젠테이션이 이미 로드된 경우 어떤 API를 사용해야 합니까?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSourceFormat--)을 사용하십시오. 로드 전에 검사가 필요하면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)를 사용하십시오.