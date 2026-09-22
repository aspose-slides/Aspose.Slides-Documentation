---
title: Android에서 프레젠테이션 저장
linktitle: 프레젠테이션 저장
type: docs
weight: 80
url: /ko/androidjava/save-presentation/
keywords:
- PowerPoint 저장
- OpenDocument 저장
- 프레젠테이션 저장
- 슬라이드 저장
- PPT 저장
- PPTX 저장
- ODP 저장
- 파일에 프레젠테이션
- 스트림에 프레젠테이션
- 미리 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 썸네일 새로 고침
- 저장 진행 상황
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Android에서 PowerPoint 및 OpenDocument 프레젠테이션을 파일이나 스트림에 저장하고, PPTX 출력 및 진행 상황 보고를 구성합니다."
---
## **개요**

프레젠테이션을 만들거나 [기존 프레젠테이션 열기](/slides/ko/androidjava/open-presentation/) 후에, [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용해 결과를 기록합니다. Aspose.Slides for Android via Java는 프레젠테이션을 PowerPoint, OpenDocument, PDF 및 기타 형식의 파일이나 스트림에 저장할 수 있습니다. 다음 섹션에서는 표준 저장 작업과 PPTX 출력에 사용할 수 있는 옵션을 다룹니다.

## **프레젠테이션을 파일에 저장**

프레젠테이션을 파일에 저장하려면 출력 경로와 [SaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/) 값을 [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드에 전달합니다. 형식 값은 Aspose.Slides가 생성하는 파일 유형을 결정합니다.

다음 예제는 프레젠테이션을 만들고 PPTX 파일로 저장합니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // 여기에 프레젠테이션 내용을 추가하거나 수정합니다.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **프레젠테이션을 원본 형식으로 저장**

파일 및 스트림 감지 예제, 새로 만든 프레젠테이션의 동작, 원본 및 출력 형식의 구분에 대해서는 [원본 프레젠테이션 형식 확인](/slides/ko/androidjava/detect-presentation-source-format/)을 참조하십시오.

배치 처리 애플리케이션에서는 입력 형식을 사전에 알 수 없을 수도 있습니다. 파일을 로드한 후 [IPresentation.getSourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) 메서드에서 원본 형식을 읽어옵니다. 얻은 [SourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sourceformat/) 값을 [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) 에 전달해 해당 [SaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/) 값을 얻은 다음, [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 로 수정된 프레젠테이션을 기록합니다.

다음 완전한 예제는 입력 디렉터리의 모든 파일을 처리하고, 제목을 업데이트한 뒤, 로드된 형식 그대로 출력 디렉터리에 저장합니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) 은 PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, PowerPoint XML을 해당 프레젠테이션 저장 형식에 매핑합니다. 이 메서드는 프레젠테이션 소스 형식만 매핑하며, PDF, HTML, TIFF 또는 이미지와 같은 내보내기 형식을 선택하기 위한 것이 아닙니다. 지원되지 않거나 잘못된 [SourceFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sourceformat/) 값을 전달하면 [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException) 이 발생합니다.

레거시 PPT, PPS 및 POT 파일은 동일한 바이너리 컨테이너를 사용합니다. 이러한 프레젠테이션을 파일 확장자 없이 스트림에서 로드하면 PPS 또는 POT 파일이 PPT 로 식별될 수 있습니다. 이러한 레거시 하위 유형을 보존해야 하는 경우, 원본 파일명이나 형식 메타데이터를 별도로 유지하고 출력 파일명 및 형식을 선택할 때 사용하십시오.

## **프레젠테이션을 스트림에 저장**

최종 파일 경로에 의존하지 않고 프레젠테이션을 기록하려면 쓰기 가능한 스트림과 [SaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/) 값을 [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) 메서드에 전달합니다. 이 방법은 출력이 웹 서비스에서 반환되거나 데이터베이스에 저장되거나 메모리에서 처리되어야 할 때 유용합니다.

다음 예제는 새 프레젠테이션을 파일 스트림에 저장합니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

저장된 프레젠테이션을 PowerPoint가 처음 열 때 표시할 보기를 지정할 수 있습니다. 저장하기 전에 [ViewProperties.setLastView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) 메서드에 [ViewType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/viewtype/) 값을 사용하십시오.

다음 예제는 슬라이드 마스터 보기를 초기 보기로 설정합니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **엄격한 Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML의 Strict 프로필에 부합하는 PPTX 파일을 만들려면 [PptxOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxoptions/) 인스턴스를 생성하고, 그 [setConformance](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) 메서드에 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) 값을 전달합니다. 그런 다음 옵션을 [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드에 전달합니다.

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 모드로 Office Open XML 형식 저장**

표준 ZIP 아카이브는 각 항목의 압축 및 비압축 크기, 전체 아카이브 크기 및 항목 수에 제한을 두고 있습니다. PPTX 파일은 ZIP 아카이브이므로 매우 큰 프레젠테이션은 이러한 제한을 초과할 수 있습니다. Zip64 확장은 적용 가능한 크기와 항목 수 제한을 늘립니다.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) 메서드를 사용해 Aspose.Slides가 Zip64 확장을 쓸지 제어합니다:

- [IfNecessary](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#IfNecessary) 은 프레젠테이션이 표준 ZIP 제한을 초과할 때만 Zip64를 사용합니다. 기본 모드입니다.
- [Never](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#Never) 은 Zip64 확장을 비활성화합니다.
- [Always](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#Always) 은 항상 Zip64 확장을 기록합니다.

다음 예제는 출력 프레젠테이션에 대해 Zip64 확장을 항상 활성화합니다:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
If [Zip64Mode.Never](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#Never) is used and the presentation cannot fit within standard ZIP limits, the save operation throws a [PptxException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **압축 수준을 지정해 Office Open XML 형식 저장**

PPTX 출력 시 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) 메서드를 사용해 저장 속도와 파일 크기 사이의 균형을 맞출 수 있습니다. [CompressionLevel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/) 클래스는 다음 값을 제공합니다:

- [None](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#None) 은 압축 없이 데이터를 저장합니다.
- [Level1](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level1) 은 가장 빠른 압축과 가장 큰 압축 파일을 제공합니다.
- [Level2](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level2) 부터 [Level5](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level5) 까지는 저장 속도보다 작은 출력 파일을 점점 우선합니다.
- [Level6](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level6) 은 저장 속도와 파일 크기의 균형을 맞춥니다. 기본 수준입니다.
- [Level7](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level7) 와 [Level8](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level8) 은 저장 속도보다 작은 출력을 더욱 우선합니다.
- [Level9](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level9) 은 가장 강력한 압축을 제공하지만 처리 시간이 가장 많이 필요합니다.

다음 예제는 압축 없이 프레젠테이션을 저장합니다:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

다음 예제는 최대 압축 수준을 사용합니다:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

프레젠테이션을 PPTX 로 저장할 때 [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 메서드가 문서 썸네일을 제어합니다:

- `true` 은 저장 작업 중에 썸네일을 다시 생성합니다. 기본값입니다.
- `false` 은 기존 썸네일을 보존합니다. 프레젠테이션에 썸네일이 없으면 Aspose.Slides 가 새로 만들지 않습니다.

다음 예제는 썸네일을 새로 고치지 않고 프레젠테이션을 저장합니다:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
썸네일 새로 고침을 비활성화하면 PPTX 파일 저장에 걸리는 시간을 줄일 수 있습니다.
{{% /alert %}}

## **백분율로 저장 진행 상황 업데이트**

저장 작업을 모니터링하려면 [IProgressCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprogresscallback/) 인터페이스를 구현하고 구현체를 [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) 메서드에 전달합니다. Aspose.Slides는 내보내기 중에 진행값을 [IProgressCallback.reporting](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) 메서드로 호출합니다.

다음 예제는 PDF 내보내기의 진행 상황을 콘솔에 출력합니다:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose는 Aspose.Slides API 로 구축된 무료 [PowerPoint Splitter](https://products.aspose.app/slides/ko/splitter) 를 제공합니다. 선택한 슬라이드를 별개의 PPT 또는 PPTX 파일로 저장할 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides 가 증분 저장 또는 “빠른 저장”을 지원합니까?**

아니요. 각 저장 작업은 변경된 부분만 업데이트하는 것이 아니라 전체 출력 파일을 새로 씁니다.

**여러 스레드가 같은 Presentation 인스턴스를 저장할 수 있나요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스는 [스레드 안전하지 않습니다](/slides/ko/androidjava/multithreading/). 인스턴스는 한 번에 하나의 스레드만 접근하고 저장해야 합니다.

**프레젠테이션을 저장할 때 하이퍼링크와 외부 파일은 어떻게 처리되나요?**

[Hyperlinks](/slides/ko/androidjava/manage-hyperlinks/) 은 프레젠테이션에 그대로 남습니다. Aspose.Slides는 외부 링크된 파일을 복사하지 않으므로 저장된 프레젠테이션은 여전히 해당 위치에 접근할 수 있어야 합니다.

**저자, 제목, 회사, 생성 날짜와 같은 문서 메타데이터를 저장할 수 있나요?**

네. 저장 전에 적절한 [document properties](/slides/ko/androidjava/presentation-properties/) 를 설정하면 Aspose.Slides 가 이를 출력 파일에 기록합니다.