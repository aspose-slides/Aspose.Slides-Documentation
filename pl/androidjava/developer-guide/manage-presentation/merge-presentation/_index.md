---
title: Efektywne scalanie prezentacji na Androidzie
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/androidjava/merge-presentation/
keywords:
- scalanie PowerPoint
- scalanie prezentacji
- scalanie slajdów
- scalanie PPT
- scalanie PPTX
- scalanie ODP
- łączenie PowerPoint
- łączenie prezentacji
- łączenie slajdów
- łączenie PPT
- łączenie PPTX
- łączenie ODP
- Android
- Java
- Aspose.Slides
description: "Bezproblemowo scalam prezentacje PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) przy użyciu Aspose.Slides dla Androida w Javie, usprawniając Twój przepływ pracy."
---
## **Przegląd**

Scalanie prezentacji PowerPoint i OpenDocument jest powszechnym zadaniem w wielu aplikacjach Android, szczególnie przy generowaniu raportów, kompilowaniu slajdów z różnych źródeł lub automatyzacji przepływów pracy prezentacji. Aspose.Slides oferuje potężne i łatwe w użyciu API, które umożliwia połączenie wielu plików PPT, PPTX lub ODP w jedną prezentację bez konieczności instalowania Microsoft PowerPoint, LibreOffice ani OpenOffice.

W tym przewodniku dowiesz się, jak scalać prezentacje PowerPoint i OpenDocument przy użyciu kilku linijek kodu. Udostępnimy gotowe przykłady i pokażemy, jak zachować formatowanie slajdów, układy oraz inne elementy prezentacji podczas procesu scalania.

Niezależnie od tego, czy tworzysz aplikację klasy korporacyjnej, czy prostą aplikację automatyzującą, Aspose.Slides umożliwia szybkie, niezawodne i skalowalne scalanie prezentacji. Aspose.Slides pozwala na łączenie prezentacji na wiele sposobów. Możesz połączyć prezentacje wraz ze wszystkimi ich kształtami, stylami, tekstem, formatowaniem, komentarzami, animacjami i nie tylko — bez obaw o utratę jakości lub danych.

{{% alert color="info" %}}

Zobacz także: [Clone Slides](https://docs.aspose.com/slides/pl/androidjava/clone-slides/)

{{% /alert %}}

### **Co można scalać**

Za pomocą Aspose.Slides możesz scalać 

* całe prezentacje. Wszystkie slajdy z prezentacji trafiają do jednej prezentacji
* wybrane slajdy. Wybrane slajdy trafiają do jednej prezentacji
* prezentacje w tym samym formacie (PPT do PPT, PPTX do PPTX itp.) oraz w różnych formatach (PPT do PPTX, PPTX do ODP itp.) ze sobą. 

### **Opcje scalania**

Możesz zastosować opcje określające, czy

* każdy slajd w prezentacji wyjściowej zachowuje unikalny styl
* określony styl jest używany dla wszystkich slajdów w prezentacji wyjściowej. 

Aby scalać prezentacje, Aspose.Slides udostępnia metody [AddClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection)). Istnieje kilka implementacji metod `AddClone`, które definiują parametry procesu scalania prezentacji. Każdy obiekt Presentation posiada kolekcję [Slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--), więc możesz wywołać metodę `AddClone` na prezentacji, do której chcesz dodać slajdy.

Metoda `AddClone` zwraca obiekt `ISlide`, który jest klonem slajdu źródłowego. Slajdy w prezentacji wyjściowej są po prostu kopią slajdów ze źródła. Dzięki temu możesz modyfikować powstałe slajdy (np. stosować style, opcje formatowania lub układy) bez obaw, że wpłynie to na prezentacje źródłowe. 

## **Scalanie prezentacji** 

Aspose.Slides udostępnia metodę [**AddClone(ISlide)**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) pozwalającą połączyć slajdy, zachowując ich układy i style (domyślne parametry).

Ten kod w Javie pokazuje, jak scalać prezentacje:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Scalanie prezentacji z szablonem Master Slide**

Aspose.Slides udostępnia metodę [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) pozwalającą połączyć slajdy, stosując szablon prezentacji master. Dzięki temu, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wyjściowej.

Ten kod w Javie demonstruje opisaną operację:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Układ slajdu dla szablonu master jest określany automatycznie. Gdy nie można ustalić odpowiedniego układu, a parametr logiczny `allowCloneMissingLayout` metody `AddClone` jest ustawiony na true, używany jest układ slajdu źródłowego. W przeciwnym razie zostanie rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

Jeśli chcesz, aby slajdy w prezentacji wyjściowej miały inny układ, użyj metody [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) podczas scalania.

## **Scalanie wybranych slajdów z prezentacji**

Scalanie wybranych slajdów z wielu prezentacji jest przydatne przy tworzeniu niestandardowych zestawów slajdów. Aspose.Slides for Android via Java umożliwia wybór i importowanie tylko potrzebnych slajdów. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.

Poniższy kod w Javie tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);

    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Scalanie prezentacji z układem slajdu**

Ten kod w Javie pokazuje, jak połączyć slajdy z różnych prezentacji, stosując wybrany układ slajdu, aby uzyskać jedną prezentację wyjściową:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Scalanie prezentacji o różnych rozmiarach slajdów**

{{% alert title="Note" color="warning" %}} 

Nie można scalać prezentacji o różnych rozmiarach slajdów. 

{{% /alert %}}

Aby scalić dwie prezentacje o różnych rozmiarach slajdów, musisz zmienić rozmiar jednej z nich, aby dopasować go do rozmiaru drugiej prezentacji.

Poniższy przykład kodu demonstruje opisaną operację:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Scalanie slajdów do sekcji prezentacji**

Ten kod w Javie pokazuje, jak scalić określony slajd z sekcją w prezentacji:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

Slajd jest dodawany na końcu sekcji. 

{{% alert title="Tip" color="info" %}}

Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz scalać obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

{{% /alert %}}

## **FAQ**

### Czy istnieją ograniczenia liczby slajdów przy scalaniu prezentacji?

Brak sztywnych ograniczeń. Aspose.Slides radzi sobie z dużymi plikami, ale wydajność zależy od rozmiaru i zasobów systemowych. Dla bardzo dużych prezentacji zaleca się użycie 64‑bitowej JVM i przydzielenie odpowiedniej pamięci heap.

### Czy mogę scalać prezentacje z osadzonym wideo lub dźwiękiem?

Tak, Aspose.Slides zachowuje treści multimedialne osadzone w slajdach, choć ostateczna prezentacja może stać się znacząco większa.

### Czy czcionki zostaną zachowane przy scalaniu prezentacji?

Tak. Czcionki użyte w prezentacjach źródłowych są zachowywane w pliku wyjściowym, o ile są zainstalowane w systemie lub [embedded](/slides/pl/androidjava/embedded-font/).