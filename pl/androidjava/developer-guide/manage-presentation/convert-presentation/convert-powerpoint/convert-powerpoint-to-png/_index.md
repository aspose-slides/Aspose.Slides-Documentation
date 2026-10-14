---
title: Konwertuj slajdy PowerPoint na PNG na Androidzie
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/androidjava/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- Android
- Java
- Aspose.Slides
description: "Szybko konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG za pomocą Aspose.Slides for Android w Javie, zapewniając precyzyjne i zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować slajdy prezentacji na obrazy PNG przy użyciu Aspose.Slides for Android w Javie. Możesz wczytywać prezentacje w formatach takich jak PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako osobny obraz PNG.

Poniższe przykłady demonstrują renderowanie w domyślnej skali, zwiększanie skali, określanie wymiarów wyjściowych w pikselach oraz wybór stylu renderowania gradientu.

## **Konwertuj PowerPoint do PNG**

Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i uzyskaj dostęp do jej slajdów poprzez kolekcję [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) . Przykład renderuje każdy slajd za pomocą [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) bez parametrów, aby utworzyć miniaturę. Następnie wywołuje [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) z [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) aby zapisać każdy wyrenderowany slajd jako obraz PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Przeciążenie [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) bez parametrów renderuje w skali 0.2. Na przykład slajd o wymiarach 720 × 540 punktów generuje miniaturę o rozmiarze 144 × 108 pikseli. Aby kontrolować wymiary wyjściowe, użyj przeciążeń ze współczynnikami skali lub explicite określonego rozmiaru obrazu, jak pokazano poniżej.
{{% /alert %}}

## **Konwertuj PowerPoint do PNG z niestandardowymi wymiarami**

Przekaż poziome i pionowe współczynniki skali do [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) , aby kontrolować renderowane wymiary. W tym przykładzie oba współczynniki wynoszą 2, więc slajd o wymiarach 720 × 540 punktów generuje obraz o rozmiarze 1440 × 1080 pikseli. Równe współczynniki skali zachowują proporcje slajdu. Każdy obraz jest zapisywany w formacie PNG przy użyciu [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PNG z niestandardowym rozmiarem**

Aby określić wymiary wyjściowe w pikselach, przekaż rozmiar do [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) zamiast współczynników skali. Ten przykład renderuje każdy slajd w rozmiarze 960 × 720 pikseli i zapisuje wynik przy użyciu [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Wybierz wymiary odpowiadające proporcjom slajdu, aby uniknąć rozciągania obrazu.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Wybierz styl renderowania gradientu**

Załóżmy, że slajd zawiera wypełnienia gradientowe, ale przejścia w wyeksportowanym PNG wyglądają jaśniej lub inaczej niż w PowerPoint. Możesz użyć metody [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) odziedziczonej po [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) , aby wybrać sposób renderowania gradientów.

Pobierz [gradient-styles.pptx](gradient-styles.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera dwa gradienty liniowe: cyjan do pomarańczowego u góry oraz niebieski do żółtego u dołu. Każdy gradient ma dwa przystanki, przy 0% i 100%.

Poniższy przykład wczytuje tę prezentację i renderuje ten sam pierwszy slajd w obu trybach przy użyciu [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Poniższe obrazy pokazują wynik tego samego slajdu, z oboma gradientami w każdym obrazie:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienty cyan-to-orange i blue-to-yellow renderowane przy użyciu Default](gradient-Default.png) | ![Te same gradienty renderowane przy użyciu PowerPointUI](gradient-PowerPointUI.png) |

W tym przykładzie `Default` generuje jaśniejsze kolory pośrednie, podczas gdy `PowerPointUI` generuje ciemniejsze kolory pośrednie. Różnica zależy od kolorów i przystanków w gradiencie.

Wybierz `Default`, gdy standardowy wynik Aspose.Slides spełnia Twoje potrzeby. Wypróbuj `PowerPointUI`, gdy priorytetem jest dopasowanie wyglądu do PowerPoint. Porównaj oba wyniki z zamierzonym rezultatem; żaden tryb nie jest uniwersalnie lepszy.

## **FAQ**

**Jak mogę wyeksportować konkretny kształt, taki jak wykres lub obraz, zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniaturek dla pojedynczych kształtów](/slides/pl/androidjava/create-shape-thumbnails/), co umożliwia renderowanie kształtu jako obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak. Używaj oddzielnej instancji prezentacji dla każdego wątku lub procesu; [nie udostępniaj jednej instancji między wątkami](/slides/pl/androidjava/multithreading/).

**Jakie są ograniczenia wersji ewaluacyjnej przy eksporcie do PNG?**

Tryb ewaluacyjny dodaje znak wodny do wyjściowych obrazów i stosuje [inne ograniczenia](/slides/pl/androidjava/licensing/), dopóki nie zostanie zastosowana licencja.