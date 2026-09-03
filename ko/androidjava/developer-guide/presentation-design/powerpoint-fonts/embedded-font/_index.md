---
title: Android에서 프레젠테이션에 글꼴 임베드
linktitle: 임베드된 글꼴
type: docs
weight: 40
url: /ko/androidjava/embedded-font/
keywords:
- 글꼴 추가
- 글꼴 임베드
- 글꼴 임베딩
- 임베드된 글꼴 가져오기
- 임베드된 글꼴 추가
- 임베드된 글꼴 제거
- 임베드된 글꼴 압축
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint의 임베드된 글꼴을 관리합니다. 글꼴을 추가, 검색, 제거 및 압축하여 텍스트 모양을 보존하고 파일 크기를 줄입니다."
---
## **소개**

임베드된 글꼴은 글꼴 데이터를 PowerPoint 프레젠테이션 내부에 저장합니다. 뷰어가 임베드된 글꼴을 지원하면 대상 시스템에 해당 글꼴이 설치되지 않아도 해당 글꼴을 사용해 텍스트를 표시할 수 있습니다. 이는 줄 바꿈, 텍스트 간격 및 슬라이드 레이아웃을 유지하는 데 도움이 됩니다.

Aspose.Slides for Android via Java를 사용하면 [IFontsManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/) 인터페이스를 통해 임베드된 글꼴을 검색, 추가 및 제거할 수 있습니다. 이 인터페이스는 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getFontsManager--) 메서드가 반환합니다. 또한 프레젠테이션에서 사용되지 않는 문자를 제거하여 임베드된 글꼴 데이터의 크기를 줄일 수 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 글꼴을 임베드하기 전에 해당 글꼴 데이터가 Aspose.Slides에서 사용 가능하고 라이선스가 임베드를 허용하는지 확인하십시오.

## **임베드된 글꼴 가져오기 및 제거**

프레젠테이션에 저장된 글꼴 목록을 확인하려면 [getEmbeddedFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--)을 사용하십시오. 글꼴을 제거하려면 해당 목록에서 글꼴을 선택하여 [removeEmbeddedFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)에 전달한 뒤 프레젠테이션을 저장합니다.

다음 예제는 `EmbeddedFonts.pptx`에 임베드된 글꼴을 나열하고 Calibri가 존재할 경우 제거합니다:

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

임베드된 글꼴을 제거하면 해당 글꼴 데이터가 삭제되지만 텍스트에 지정된 글꼴이 변경되지는 않습니다. 대상 시스템에 글꼴이 설치되어 있으면 텍스트는 여전히 해당 글꼴을 사용할 수 있습니다. 그렇지 않은 경우 렌더링 시 [font substitution](/slides/ko/androidjava/font-substitution/)이 필요할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **글꼴 데이터 및 임베드 권한 검사**

임베드하기 전에 글꼴을 검사하려면 [IFontsManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/) 인터페이스를 사용하십시오. 프레젠테이션에 사용된 글꼴을 검색하려면 [IFontsManager.getFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getFonts--)을 호출합니다. 각 글꼴에 대해 [IFontData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontdata/) 객체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontstyletype/) 값을 [IFontsManager.getFontBytes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-)에 전달합니다. 이 메서드는 해당 글꼴 스타일의 바이너리 데이터를 반환하며, 요청한 글꼴이나 스타일이 없으면 `null`을 반환합니다. `null` 결과를 [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-)에 전달하지 마십시오. 이 메서드는 바이트 배열을 필요로 합니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/embeddinglevel/)은 글꼴에 저장된 임베드 제한을 보고하는 플래그 열거형입니다:

- `Installable`은 글꼴 라이선스에 따라 다른 시스템에 임베드 및 영구 설치를 허용합니다.
- `Restricted`는 사용 권한 플래그가 `Restricted`만 있는 경우, 글꼴 소유자로부터 허가를 받지 않으면 임베드를 금지합니다.
- `PreviewPrint`는 보기 및 인쇄를 위한 임시 사용을 허용합니다. 해당 글꼴이 포함된 문서는 읽기 전용이어야 합니다.
- `Editable`은 임시 사용을 허용하며 문서를 편집하고 저장할 수 있게 합니다.
- `NoSubsetting`은 추가 제한으로, 글리프의 일부만 임베드하는 것을 금지합니다. 이 플래그가 있는 경우 모든 문자를 임베드합니다.
- `BitmapOnly`는 추가 제한으로, 비트맵 스트라이크만 임베드할 수 있고 윤곽 데이터는 임베드할 수 없습니다. 글꼴에 비트맵 스트라이크가 없으면 임베드할 수 없습니다.

첫 네 값은 사용 권한을 설명하고, `NoSubsetting`과 `BitmapOnly`는 함께 결합될 수 있습니다. 비트 연산을 사용해 수정자를 확인하십시오. `Installable`이 0이므로 사용 권한 비트를 마스크하고 결과를 `Installable`과 비교해야 플래그로 검사하는 대신 올바르게 판단할 수 있습니다. 현재 글꼴은 최대 하나의 사용 권한 비트를 설정해야 합니다. 하나 이상 설정된 옛 글꼴과의 호환성을 위해 아래 도우미는 가장 제한이 적은 권한을 선택합니다: `Editable`, 다음 `PreviewPrint`, 마지막 `Restricted`.

다음 예제는 `getFonts`가 반환하는 각 글꼴에 대해 일반, 굵게, 기울임 및 굵게‑기울임 스타일 데이터를 감사합니다. 사용 불가능한 스타일, 제한된 글꼴, 비트맵 전용 글꼴, 미리 보기·인쇄만 허용되는 글꼴(출력이 편집 가능하게 유지됨) 및 이미 임베드된 글꼴은 건너뜁니다. 사용 가능한 스타일 중 `NoSubsetting`이 있으면 해당 글꼴 패밀리의 모든 문자를 임베드합니다.

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

이 검사는 각 글꼴 파일에 인코딩된 제한을 보고합니다. 라이선스를 부여하거나 글꼴을 합법적으로 확보했음을 증명하거나, 임베드된 사본을 배포하기 전에 글꼴 라이선스 계약을 확인하는 절차를 대신하지는 않습니다.

## **임베드된 글꼴 추가**

글꼴을 임베드하려면 [addEmbeddedFont](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)를 사용하십시오. 이 메서드의 오버로드는 [IFontData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontdata/) 객체 또는 글꼴 데이터를 포함하는 바이트 배열을 받아들입니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/embedfontcharacters/) 열거형은 포함할 문자를 제어합니다:

- [All](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/embedfontcharacters/) 은 글꼴의 모든 문자를 임베드합니다. 받는 사람이 프레젠테이션을 편집하고 새 텍스트를 입력해야 할 경우 이 옵션을 사용합니다.
- [OnlyUsed](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/embedfontcharacters/) 은 프레젠테이션에 사용된 문자만 임베드하여 파일 크기를 줄입니다. 주로 보기용으로 제공되는 최종 프레젠테이션에 이 옵션을 선택하십시오.

다음 예제는 `Fonts.pptx`에 사용된 글꼴을 검색하기 위해 [getFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getFonts--)을 사용하고, 아직 임베드되지 않은 글꼴을 임베드합니다. 추가할 글꼴은 Android 기기에 있어야 하거나 Aspose.Slides에 등록되어 있어야 합니다. 기존에 임베드된 글꼴은 현재 문자 집합을 유지합니다.

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

## **임베드된 글꼴 압축**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 은 사용되지 않는 문자를 제거하여 임베드된 글꼴 데이터를 감소시킵니다. 이미 임베드된 글꼴에 적용되므로, 크기 감소량은 프레젠테이션에 포함된 사용되지 않은 글꼴 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx`의 글꼴을 압축하고 결과를 별도 파일로 저장합니다:

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

받는 사람이 나중에 텍스트를 추가해야 할 가능성이 있다면 원본 파일을 보관하십시오. 압축 과정에서 제거된 문자는 원래 모든 문자를 임베드했더라도 임베드된 글꼴에서 더 이상 사용할 수 없습니다.

## **FAQ**

**임베드된 글꼴이 렌더링 시 여전히 대체되는지 어떻게 확인할 수 있나요?**

프레젠테이션을 렌더링하는 환경에서 [getSubstitutions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--)을 호출하여 Aspose.Slides가 교체할 글꼴을 확인하십시오. 또한 [font substitution](/slides/ko/androidjava/font-substitution/) 설정과 [font fallback](/slides/ko/androidjava/fallback-font/) 규칙을 확인하세요. 폴백은 누락된 문자를 처리하므로, 글꼴 자체에 포함되지 않은 문자는 임베드만으로 해결되지 않습니다.

**Arial 및 Calibri와 같은 일반 글꼴을 임베드해야 할까요?**

대상 환경을 기준으로 판단하십시오. 필요한 글꼴이 프레젠테이션을 열거나 렌더링하는 모든 장치에 이미 설치되어 있다면 임베드가 불필요한 파일 크기를 증가시킬 수 있습니다. 받는 사람이나 서버에 해당 글꼴이 없을 가능성이 있다면, 라이선스가 허용하는 한 임베드하여 의도된 화면을 유지하는 것이 도움이 됩니다.