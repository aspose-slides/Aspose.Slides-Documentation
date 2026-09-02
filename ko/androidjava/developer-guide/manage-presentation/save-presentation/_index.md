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
- 저장 진행률
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java에서 프레젠테이션을 저장하는 방법을 알아보세요—레이아웃, 글꼴 및 효과를 유지하면서 PowerPoint 또는 OpenDocument로 내보낼 수 있습니다."
---
## **개요**

[Open Presentations on Android](/slides/ko/androidjava/open-presentation/) 는 프레젠테이션을 열기 위해 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스를 사용하는 방법을 설명합니다. 이 문서는 프레젠테이션을 만들고 저장하는 방법을 설명합니다. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스는 프레젠테이션의 내용을 포함합니다. 처음부터 프레젠테이션을 만들든 기존 것을 수정하든, 완료 후에는 저장해야 합니다. Aspose.Slides for Android를 사용하면 **파일** 또는 **스트림**에 저장할 수 있습니다. 이 문서는 프레젠테이션을 저장하는 다양한 방법을 설명합니다.

## **파일에 프레젠테이션 저장**

프레젠테이션을 파일에 저장하려면 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 `save` 메서드를 호출합니다. 메서드에 파일 이름과 저장 형식을 전달합니다. 다음 예제는 Aspose.Slides를 사용하여 프레젠테이션을 저장하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 여기서 작업을 수행합니다...

    // 프레젠테이션을 파일에 저장합니다.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **스트림에 프레젠테이션 저장**

출력 스트림을 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 `save` 메서드에 전달하여 프레젠테이션을 스트림에 저장할 수 있습니다. 프레젠테이션은 다양한 스트림 유형에 기록될 수 있습니다. 아래 예제에서는 새 프레젠테이션을 생성하고 파일 스트림에 저장합니다.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // 프레젠테이션을 스트림에 저장합니다.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 생성된 프레젠테이션이 열릴 때 PowerPoint가 사용하는 초기 보기를 [ViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/viewproperties/) 클래스를 통해 설정할 수 있습니다. [ViewType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/viewtype/) 열거형의 값을 사용하여 [setLastView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) 메서드를 호출합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Aspose.Slides를 사용하면 프레젠테이션을 Strict Office Open XML 형식으로 저장할 수 있습니다. 저장할 때 [PptxOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxoptions/) 클래스를 사용하고 그들의 conformance 속성을 설정합니다. [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict)를 설정하면 출력 파일이 Strict Office Open XML 형식으로 저장됩니다.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 프레젠테이션을 Strict Office Open XML 형식으로 저장합니다.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 모드로 Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML 파일은 4GB(2^32 바이트) 제한을 가진 ZIP 아카이브이며, 압축되지 않은 파일 크기, 압축된 파일 크기, 전체 아카이브 크기 및 파일 수(65,535개) 등에 제한이 있습니다. ZIP64 형식 확장은 이러한 제한을 2^64까지 확대합니다.

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) 메서드를 사용하면 Office Open XML 파일을 저장할 때 ZIP64 형식 확장을 언제 사용할지 선택할 수 있습니다.

이 메서드는 다음 모드와 함께 사용할 수 있습니다:

- [IfNecessary](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#IfNecessary) 은 프레젠테이션이 위의 제한을 초과할 경우에만 ZIP64 형식 확장을 사용합니다. 기본 모드입니다.
- [Never](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#Never) 은 ZIP64 형식 확장을 절대 사용하지 않습니다.
- [Always](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#Always) 은 항상 ZIP64 형식 확장을 사용합니다.

다음 코드는 ZIP64 형식 확장이 활성화된 상태로 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/zip64mode/#Never) 로 저장하면 프레젠테이션을 ZIP32 형식으로 저장할 수 없을 경우 [PptxException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxexception/) 이 발생합니다.
{{% /alert %}}

## **압축 수준을 지정하여 Office Open XML 형식으로 프레젠테이션 저장**

큰 프레젠테이션을 다룰 때 파일 크기와 처리 시간을 균형 있게 맞추기 위해 압축 수준을 조정할 수 있습니다. 요구 사항에 따라 더 빠른 처리 속도나 더 작은 출력 파일을 선호할 수 있습니다.

Aspose.Slides는 [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) 메서드를 제공하여 Office Open XML 형식으로 프레젠테이션을 저장할 때 사용할 압축 수준을 지정할 수 있습니다.

다음 압축 수준을 사용할 수 있습니다:

- [**None**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#None): 압축이 적용되지 않으며 파일이 그대로 저장됩니다.
- [**Level1**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level1): 가장 빠른 압축이며 압축 비율이 가장 낮습니다.
- [**Level2**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level2): **Level1**보다 약간 더 나은 압축 비율을 제공하면서도 빠른 압축을 수행합니다.
- [**Level3**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level3): **Level2**보다 더 나은 압축을 제공하지만 처리 시간에 중간 정도 영향을 미칩니다.
- [**Level4**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level4): **Level3**보다 더 나은 압축을 제공합니다.
- [**Level5**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level5): **Level4**보다 향상된 압축을 제공하지만 추가적인 처리 시간이 필요합니다.
- [**Level6**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level6): 표준 압축으로 처리 속도와 파일 크기 사이에 좋은 균형을 제공합니다. 이것이 *기본 압축 수준*입니다.
- [**Level7**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level7): **Level6**보다 더 나은 압축을 제공하지만 처리 속도가 느립니다.
- [**Level8**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level8): **Level7**보다 더 나은 압축을 제공합니다.
- [**Level9**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compressionlevel/#Level9): 최대 압축으로, 가장 작은 파일 크기를 얻지만 가장 오래 걸리는 처리 시간을 필요로 합니다.

다음 예제는 압축 없이 PPTX 파일로 프레젠테이션을 저장하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

다음 예제는 최대 압축으로 PPTX 파일에 프레젠테이션을 저장하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **썸네일을 새로 고치지 않고 프레젠테이션 저장**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) 메서드는 PPTX로 저장할 때 썸네일 생성 여부를 제어합니다:

- `true` 로 설정하면 저장 시 썸네일이 새로 고쳐집니다. 기본값입니다.
- `false` 로 설정하면 현재 썸네일이 유지됩니다. 프레젠테이션에 썸네일이 없으면 생성되지 않습니다.

아래 코드에서는 썸네일을 새로 고치지 않고 PPTX로 프레젠테이션을 저장합니다.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
이 옵션은 PPTX 형식으로 프레젠테이션을 저장하는 데 필요한 시간을 줄이는 데 도움이 됩니다.
{{% /alert %}}

## **저장 진행률을 백분율로 업데이트**

[IProgressCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprogresscallback/) 인터페이스는 [ISaveOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isaveoptions/) 인터페이스와 추상 [SaveOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveoptions/) 클래스가 노출하는 `setProgressCallback` 메서드를 통해 사용됩니다. `setProgressCallback` 에 [IProgressCallback](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprogresscallback/) 구현을 할당하면 저장 진행 상황을 백분율로 받을 수 있습니다.

다음 코드 스니펫은 `IProgressCallback`을 사용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // 여기서 진행률 백분율 값을 사용합니다.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose는 자체 API를 사용하여 [무료 PowerPoint Splitter 앱](https://products.aspose.app/slides/ko/splitter) 을 개발했습니다. 이 앱은 선택한 슬라이드를 새 PPTX 또는 PPT 파일로 저장하여 프레젠테이션을 여러 파일로 분할할 수 있게 해줍니다.
{{% /alert %}}

## **FAQ**

**"빠른 저장"(증분 저장)이 지원되어 변경된 부분만 기록되나요?**

아니요. 저장할 때마다 전체 대상 파일을 새로 생성합니다; 증분 '빠른 저장'은 지원되지 않았습니다.

**다중 스레드에서 동일한 Presentation 인스턴스를 저장하는 것이 스레드 안전한가요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스는 [스레드 안전하지 않음](/slides/ko/androidjava/multithreading/); 단일 스레드에서 저장해야 합니다.

**저장할 때 하이퍼링크와 외부 연결 파일은 어떻게 되나요?**

[Hyperlinks](/slides/ko/androidjava/manage-hyperlinks/) 은 유지됩니다. 외부 연결 파일(예: 상대 경로를 사용하는 비디오)은 자동으로 복사되지 않으므로 참조된 경로가 계속 접근 가능하도록 해야 합니다.

**문서 메타데이터(작성자, 제목, 회사, 날짜)를 설정/저장할 수 있나요?**

예. 표준 [문서 속성](/slides/ko/androidjava/presentation-properties/)이 지원되며 저장 시 파일에 기록됩니다.