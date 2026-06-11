---
title: Efektywne scalanie prezentacji w Javie
linktitle: Skalanie prezentacji
type: docs
weight: 40
url: /pl/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Bezproblemowo scalaj prezentacje PowerPoint (PPT, PPTX) i OpenDocument (ODP) za pomocą Aspose.Slides dla Javy, usprawniając swój przepływ pracy."
---
## **Przegląd**

Scalanie prezentacji PowerPoint i OpenDocument jest powszechnym zadaniem w wielu aplikacjach Java, szczególnie przy generowaniu raportów, zestawianiu slajdów z różnych źródeł lub automatyzacji procesów prezentacji. Aspose.Slides for Java udostępnia potężne i łatwe w użyciu API do łączenia wielu plików PPT, PPTX lub ODP w jedną prezentację bez konieczności instalowania Microsoft PowerPoint, LibreOffice ani OpenOffice.

W tym przewodniku poznasz, jak scalać prezentacje PowerPoint i OpenDocument przy użyciu kilku linii kodu Java. Udostępnimy gotowe przykłady i pokażemy, jak zachować formatowanie slajdów, układy oraz inne elementy prezentacji podczas procesu scalania.

Niezależnie od tego, czy tworzysz aplikację klasy korporacyjnej, czy prostą aplikację automatyzującą, Aspose.Slides umożliwia szybkie, niezawodne i skalowalne scalanie prezentacji w Javie. Aspose.Slides for Java pozwala scalać prezentacje na różne sposoby. Możesz łączyć prezentacje ze wszystkimi ich kształtami, stylami, tekstem, formatowaniem, komentarzami, animacjami i nie tylko — bez obawy o utratę jakości lub danych.

{{% alert color="primary" %}}

Zobacz także: [Klonowanie slajdów](https://docs.aspose.com/slides/pl/java/clone-slides/)

{{% /alert %}}

### **Co można scalić?**

Za pomocą Aspose.Slides możesz scalać:

**Pełne prezentacje** – wszystkie slajdy z wielu prezentacji są łączone w jedną.

**Konkretne slajdy** – tylko wybrane slajdy są scalane w jedną prezentację.

**Prezentacje w tym samym formacie** (np. PPT do PPT, PPTX do PPTX) oraz **w różnych formatach** (np. PPT do PPTX, PPTX do ODP).

### **Opcje scalania**

Możesz zastosować opcje określające, czy:

- Każdy slajd w prezentacji wynikowej zachowuje swój oryginalny styl
- Na wszystkie slajdy w prezentacji wynikowej zostanie zastosowany określony styl

Aby scalać prezentacje, Aspose.Slides udostępnia metody `AddClone` z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/). Istnieje kilka przeciążeń metody `AddClone`, które definiują zachowanie procesu scalania. Każdy obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) posiada kolekcję Slides. Dlatego możesz wywołać metodę `AddClone` na docelowej prezentacji, do której chcesz scalić slajdy.

Metoda `AddClone` zwraca obiekt [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/), będący klonem slajdu źródłowego. Powstałe slajdy w prezentacji wynikowej są po prostu kopiami oryginalnych slajdów. Oznacza to, że możesz bezpiecznie modyfikować sklonowane slajdy — np. stosować style, opcje formatowania lub układy — bez wpływu na prezentację źródłową.

## **Scalanie prezentacji**

Aspose.Slides udostępnia metodę [AddClone(ISlide)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) umożliwiającą łączenie slajdów przy zachowaniu ich pierwotnych układów i stylów (domyślne zachowanie).

Poniższy kod Java pokazuje, jak scalać prezentacje:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **Scalanie prezentacji z masterem slajdów**

Aspose.Slides udostępnia metodę [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) umożliwiającą łączenie slajdów przy zastosowaniu mastera slajdów z szablonu prezentacji. Dzięki temu, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wynikowej.

Poniższy kod Java demonstruje tę operację:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}

Układ slajdu jest określany automatycznie. Gdy nie można znaleźć odpowiedniego układu, a parametr `allowCloneMissingLayout` metody `AddClone` jest ustawiony na `true`, używany jest układ ze slajdu źródłowego. W przeciwnym razie zgłaszany jest [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Scalanie wybranych slajdów z prezentacji**

Scalanie konkretnych slajdów z wielu prezentacji jest przydatne przy tworzeniu dedykowanych zestawów slajdów. Aspose.Slides for Java pozwala wybrać i zaimportować wyłącznie potrzebne slajdy. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.

Poniższy kod Java tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:

```java
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

Aby podczas scalania zastosować inny układ slajdu do slajdów wynikowych, użyj metody [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) zamiast.

Poniższy kod Java pokazuje, jak łączyć slajdy z wielu prezentacji, stosując wybrany układ slajdu, co daje jedną prezentację wynikową:

```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **Scalanie prezentacji o różnych rozmiarach slajdów**

Aby scalić dwie prezentacje o różnych rozmiarach slajdów, należy dopasować rozmiar jednej z nich do rozmiaru slajdu drugiej prezentacji.

Poniższy kod Java demonstruje tę operację:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **Scalanie slajdów do sekcji prezentacji**

Scalanie slajdów do określonej sekcji prezentacji pomaga uporządkować treść i usprawnia nawigację po slajdach. Aspose.Slides umożliwia scalanie slajdów do istniejących sekcji, zapewniając klarowną strukturę przy zachowaniu pierwotnego formatowania każdego slajdu.

Poniższy kod Java pokazuje, jak scalić konkretny slajd do sekcji w prezentacji:

```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

Slajd jest dodawany na koniec sekcji.

## **Zobacz również**

Aspose udostępnia [FREE Online Collage Maker](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz scalać [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i więcej.

Sprawdź [Aspose FREE Online Merger](https://products.aspose.app/slides/pl/merger). Umożliwia on scalanie prezentacji PowerPoint w tym samym formacie (np. PPT do PPT, PPTX do PPTX) lub w różnych formatach (np. PPT do PPTX, PPTX do ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/pl/merger)

Oprócz prezentacji, Aspose.Slides pozwala scalać także inne pliki:

- [**Obrazy**](https://products.aspose.com/slides/pl/java/merger/image-to-image/), takie jak [JPG do JPG](https://products.aspose.com/slides/pl/java/merger/jpg-to-jpg/) lub [PNG do PNG](https://products.aspose.com/slides/pl/java/merger/png-to-png/)
- **Dokumenty**, takie jak [PDF do PDF](https://products.aspose.com/slides/pl/java/merger/pdf-to-pdf/) lub [HTML do HTML](https://products.aspose.com/slides/pl/java/merger/html-to-html/)
- **Mieszane typy plików**, takie jak [obraz do PDF](https://products.aspose.com/slides/pl/java/merger/image-to-pdf/), [JPG do PDF](https://products.aspose.com/slides/pl/java/merger/jpg-to-pdf/) lub [TIFF do PDF](https://products.aspose.com/slides/pl/java/merger/tiff-to-pdf/)

## **FAQ**

**Czy istnieją ograniczenia liczby slajdów przy scalaniu prezentacji?**

Brak sztywnych ograniczeń. Aspose.Slides radzi sobie z dużymi plikami, ale wydajność zależy od rozmiaru i zasobów systemu. Przy bardzo dużych prezentacjach zaleca się użycie 64‑bitowej JVM oraz przydzielenie odpowiedniej ilości pamięci heap.

**Czy mogę scalać prezentacje z osadzonym wideo lub dźwiękiem?**

Tak, Aspose.Slides zachowuje treści multimedialne osadzone w slajdach, choć końcowa prezentacja może stać się znacząco większa.

**Czy czcionki zostaną zachowane przy scalaniu prezentacji?**

Tak. Czcionki użyte w prezentacjach źródłowych są zachowywane w pliku wynikowym, pod warunkiem że są zainstalowane w systemie lub [embedded](/slides/pl/java/embedded-font/).