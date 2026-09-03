---
title: Java에서 프레젠테이션에 폰트 삽입
linktitle: 삽입된 폰트
type: docs
weight: 40
url: /ko/java/embedded-font/
keywords:
- 폰트 추가
- 폰트 삽입
- 폰트 삽입
- 삽입된 폰트 가져오기
- 삽입된 폰트 추가
- 삽입된 폰트 제거
- 삽입된 폰트 압축
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint의 삽입된 폰트를 관리합니다. 폰트를 추가, 검색, 제거 및 압축하여 텍스트 모양을 유지하고 파일 크기를 줄입니다."
---
## **소개**

폰트 삽입은 폰트 데이터를 PowerPoint 프레젠테이션 내부에 저장합니다. 뷰어가 삽입된 폰트를 지원하면 대상 시스템에 폰트가 설치되지 않아도 해당 폰트로 텍스트를 표시할 수 있습니다. 이는 줄 바꿈, 텍스트 간격 및 슬라이드 레이아웃을 유지하는 데 도움이 됩니다.

Aspose.Slides for Java를 사용하면 [IFontsManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/) 인터페이스를 통해 삽입된 폰트를 검색, 추가 및 제거할 수 있습니다. 이 인터페이스는 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getFontsManager--)에서 반환됩니다. 또한 프레젠테이션에서 사용하지 않는 문자를 제거하여 삽입된 폰트 데이터 크기를 줄일 수 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 폰트를 삽입하기 전에 해당 폰트 데이터가 Aspose.Slides에서 사용 가능하고 라이선스가 삽입을 허용하는지 확인하십시오.

## **삽입된 폰트 가져오기 및 제거**

[getEmbeddedFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--)을 사용하여 프레젠테이션에 저장된 폰트를 나열합니다. 하나를 제거하려면 해당 목록에서 폰트를 [removeEmbeddedFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)에 전달한 후 프레젠테이션을 저장합니다.

다음 예제는 `EmbeddedFonts.pptx` 파일에 포함된 폰트를 나열하고, Calibri가 존재하면 제거합니다:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

삽입된 폰트를 제거하면 저장된 폰트 데이터가 삭제되지만 텍스트에 할당된 폰트는 변경되지 않습니다. 대상 시스템에 해당 폰트가 설치되어 있으면 텍스트는 계속 사용할 수 있습니다. 그렇지 않으면 렌더링 시 [font substitution](/slides/ko/java/font-substitution/)이 필요할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **폰트 데이터 및 삽입 권한 검사**

삽입하기 전에 폰트를 검사하려면 [IFontsManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/) 인터페이스를 사용합니다. 프레젠테이션에서 사용된 폰트를 가져오려면 [IFontsManager.getFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getFonts--)을 호출합니다. 각 폰트에 대해 [IFontData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontdata/) 객체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontstyletype/) 값을 [IFontsManager.getFontBytes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-)에 전달합니다. 이 메서드는 해당 폰트 스타일의 바이너리 데이터를 반환하거나, 요청된 폰트나 스타일을 사용할 수 없을 경우 `null`을 반환합니다. `null` 결과를 [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-)에 전달하지 마세요. 해당 메서드는 바이트 배열을 필요로 합니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/java/com.aspose.slides/embeddinglevel/)은 폰트에 저장된 삽입 제한을 보고하는 플래그 열거형입니다:

- `Installable`은 폰트 라이선스에 따라 다른 시스템에 삽입 및 영구 설치를 허용합니다.
- `Restricted`는 사용 권한 플래그가 하나뿐일 때 폰트 소유자의 허가 없이는 삽입을 금지합니다.
- `PreviewPrint`는 보기 및 인쇄를 위한 일시적 사용을 허용합니다; 폰트를 포함한 문서는 읽기 전용이어야 합니다.
- `Editable`은 일시적 사용을 허용하며 문서를 편집하고 저장할 수 있게 합니다.
- `NoSubsetting`은 글리프의 일부만 삽입하는 것을 금지하는 추가 제한이며, 이 플래그가 있으면 모든 문자를 삽입해야 합니다.
- `BitmapOnly`는 비트맵 스트라이크만 삽입을 허용하고 외곽선 데이터는 삽입하지 못하도록 하는 추가 제한입니다. 폰트에 비트맵 스트라이크가 없으면 삽입할 수 없습니다.

첫 네 값은 사용 권한을 나타내며, `NoSubsetting` 및 `BitmapOnly`는 이들과 결합될 수 있습니다. 비트 연산을 사용하여 수정자를 확인하세요. `Installable`은 0이므로 사용 권한 비트를 마스크하고 결과를 `Installable`과 비교하여 플래그로 확인하지 마세요. 현재 폰트는 최대 하나의 사용 권한 비트만 설정해야 합니다. 여러 개의 사용 권한 비트를 설정한 오래된 폰트와 호환되도록 아래 도우미는 가장 제한이 적은 권한을 선택합니다: `Editable`, 다음으로 `PreviewPrint`, 그리고 `Restricted`.

다음 예제는 `getFonts`가 반환하는 모든 폰트에 대해 일반, 굵게, 기울임, 굵게 기울임 스타일 데이터를 검사합니다. 사용할 수 없는 스타일, 제한된 폰트, 비트맵 전용 폰트, 출력이 편집 가능한 상태를 유지하기 위해 미리 보기 및 인쇄에만 제한된 폰트, 이미 삽입된 폰트를 건너뜁니다. 사용 가능한 스타일 중 `NoSubsetting`이 있는 경우 해당 폰트 패밀리의 모든 문자를 삽입합니다.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 검사는 각 폰트 파일에 인코딩된 제한 사항을 보고합니다. 이는 라이선스를 부여하거나 폰트를 합법적으로 획득했음을 증명하지 않으며, 삽입된 복사본을 배포하기 전에 폰트 라이선스 계약을 확인하는 것을 대신하지 않습니다.

## **삽입된 폰트 추가**

[addEmbeddedFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)을 사용하여 폰트를 삽입합니다. 해당 오버로드는 [IFontData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontdata/) 객체 또는 폰트 데이터를 포함하는 바이트 배열을 허용합니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/java/com.aspose.slides/embedfontcharacters/) 열거형은 포함할 문자를 제어합니다:

- [All](https://reference.aspose.com/slides/ko/java/com.aspose.slides/embedfontcharacters/)은 폰트의 모든 문자를 삽입합니다. 수신자가 프레젠테이션을 편집하고 새로운 텍스트를 입력해야 할 경우 이 옵션을 사용합니다.
- [OnlyUsed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/embedfontcharacters/)은 프레젠테이션에 사용된 문자만 삽입하여 파일 크기를 줄입니다. 주로 보기용으로 제공되는 완성된 프레젠테이션에 이 옵션을 선택합니다.

다음 예제는 [getFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getFonts--)를 사용하여 `Fonts.pptx`에서 사용된 폰트를 가져오고 아직 삽입되지 않은 폰트를 삽입합니다. 추가할 폰트는 코드를 실행하는 머신에 있어야 합니다. 기존에 삽입된 폰트는 현재 문자 집합을 유지합니다.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **삽입된 폰트 압축**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-)은 사용되지 않은 문자를 제거하여 삽입된 폰트 데이터를 줄입니다. 이미 삽입된 폰트에 대해 작동하므로 크기 감소는 프레젠테이션에 포함된 미사용 폰트 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx`의 폰트를 압축하고 결과를 별도 파일로 저장합니다:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

수신자가 이후에 텍스트를 추가해야 할 경우 원본 파일을 보관하십시오. 압축 중에 제거된 문자는 원래 모든 문자를 삽입했더라도 삽입된 폰트에서 더 이상 사용할 수 없습니다.

## **FAQ**

**렌더링 중에 삽입된 폰트가 여전히 대체되는지 어떻게 확인할 수 있나요?**

프레젠테이션을 렌더링하는 환경에서 [getSubstitutions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)을 호출하면 Aspose.Slides가 교체할 폰트를 확인할 수 있습니다. 또한 [font substitution](/slides/ko/java/font-substitution/) 설정 및 [font fallback](/slides/ko/java/fallback-font/) 규칙을 확인하십시오. 폰트 대체는 누락된 문자를 처리하므로, 폰트를 삽입해도 해당 폰트에 포함되지 않은 문자는 해결되지 않습니다.

**Arial 및 Calibri와 같은 일반 폰트를 삽입해야 할까요?**

대상 환경을 기준으로 결정하십시오. 필요 폰트가 프레젠테이션을 열거나 렌더링하는 모든 머신에 존재한다면 삽입은 불필요한 파일 크기를 증가시킬 수 있습니다. 수신자나 서버에 해당 폰트가 없을 경우, 라이선스가 허용한다면 삽입을 통해 의도한 외관을 유지할 수 있습니다.