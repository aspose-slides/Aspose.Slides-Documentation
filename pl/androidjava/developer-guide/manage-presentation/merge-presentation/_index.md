---
title: Efektywne scalanie prezentacji na Androidzie
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/androidjava/merge-presentation/
keywords:
- scal PowerPoint
- scal prezentacje
- scal slajdy
- scal PPT
- scal PPTX
- scal ODP
- połącz PowerPoint
- połącz prezentacje
- połącz slajdy
- połącz PPT
- połącz PPTX
- połącz ODP
- Android
- Java
- Aspose.Slides
description: "Bez wysiłku scalaj prezentacje PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) za pomocą Aspose.Slides dla Androida w Javie, usprawniając swój przepływ pracy."
---
## **Przegląd**

Łączenie prezentacji PowerPoint i OpenDocument jest powszechnym zadaniem w wielu aplikacjach Android, szczególnie przy generowaniu raportów, kompilowaniu slajdów z różnych źródeł lub automatyzacji przepływów pracy prezentacji. Aspose.Slides udostępnia potężne i łatwe w użyciu API do łączenia wielu plików PPT, PPTX lub ODP w jedną prezentację bez instalowania Microsoft PowerPoint, LibreOffice ani OpenOffice.

W tym przewodniku nauczysz się, jak łączyć prezentacje PowerPoint i OpenDocument przy użyciu zaledwie kilku linii kodu. Dostarczymy gotowe przykłady oraz pokażemy, jak zachować formatowanie slajdów, układy i inne elementy prezentacji podczas procesu scalania.

Niezależnie od tego, czy tworzysz aplikację klasy korporacyjnej, czy prostą narzędzie automatyzacji, Aspose.Slides umożliwia szybkie, niezawodne i skalowalne łączenie prezentacji. Aspose.Slides pozwala łączyć prezentacje na różne sposoby. Możesz połączyć prezentacje ze wszystkimi ich kształtami, stylami, tekstem, formatowaniem, komentarzami, animacjami i nie tylko — bez obaw o utratę jakości lub danych.

{{% alert color="primary" %}}
Zobacz także: [Clone Slides](https://docs.aspose.com/slides/pl/androidjava/clone-slides/)
{{% /alert %}}

### **Co można scalić**

Z Aspose.Slides możesz scalić 

* całe prezentacje. Wszystkie slajdy z prezentacji trafiają do jednej prezentacji
* konkretne slajdy. Wybrane slajdy trafiają do jednej prezentacji
* prezentacje w jednym formacie (PPT do PPT, PPTX do PPTX itp.) i w różnych formatach (PPT do PPTX, PPTX do ODP itp.) między sobą. 

### **Opcje scalania**

Możesz zastosować opcje, które określają, czy

* każdy slajd w prezentacji wynikowej zachowuje unikalny styl
* określony styl jest używany dla wszystkich slajdów w prezentacji wynikowej. 

Aby scalić prezentacje, Aspose.Slides udostępnia metody [AddClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection)). Istnieje kilka implementacji metod `AddClone`, które definiują parametry procesu scalania prezentacji. Każdy obiekt Presentation ma kolekcję [Slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) , więc możesz wywołać metodę `AddClone` z prezentacji, do której chcesz scalić slajdy.

Metoda `AddClone` zwraca obiekt `ISlide`, będący klonem slajdu źródłowego. Slajdy w prezentacji wynikowej są po prostu kopią slajdów ze źródła. Dlatego możesz wprowadzać zmiany w powstałych slajdach (np. stosować style, opcje formatowania lub układy) bez obaw o wpływ na prezentacje źródłowe.

## **Scalanie prezentacji** 

Aspose.Slides udostępnia metodę [**AddClone(ISlide)**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) umożliwiającą łączenie slajdów przy zachowaniu ich układów i stylów (parametry domyślne).

Ten kod w języku Java pokazuje, jak scalić prezentacje:

```java
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

## **Scalanie prezentacji z masterem slajdów** 

Aspose.Slides udostępnia metodę [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) umożliwiającą łączenie slajdów przy zastosowaniu szablonu mastera prezentacji. W ten sposób, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wynikowej.

Ten kod w języku Java demonstruje opisaną operację:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
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
Układ slajdu dla mastera jest określany automatycznie. Gdy nie można określić odpowiedniego układu, jeśli parametr boolowski `allowCloneMissingLayout` metody `AddClone` jest ustawiony na true, używany jest układ slajdu źródłowego. W przeciwnym razie zostanie rzucony wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

Jeśli chcesz, aby slajdy w prezentacji wynikowej miały inny układ slajdu, użyj metody [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) podczas scalania.

## **Scalanie konkretnych slajdów z prezentacji** 

Scalanie konkretnych slajdów z wielu prezentacji jest przydatne przy tworzeniu niestandardowych zestawów slajdów. Aspose.Slides dla Android przy użyciu Javy pozwala wybrać i zaimportować tylko potrzebne slajdy. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.

Poniższy kod w języku Java tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:

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

Ten kod w języku Java pokazuje, jak połączyć slajdy z prezentacji, stosując wybrany układ slajdu, aby uzyskać jedną prezentację wynikową:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
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

Aby scalić 2 prezentacje o różnych rozmiarach slajdów, musisz zmienić rozmiar jednej z nich, aby dopasować go do rozmiaru drugiej prezentacji.

Przykładowy kod demonstruje opisaną operację:

```java
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

Ten kod w języku Java pokazuje, jak scalić określony slajd do sekcji w prezentacji:

```java
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

{{% alert title="Tip" color="primary" %}} 
Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz scalać obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i inne. 
{{% /alert %}}

## **FAQ**

**Czy istnieją ograniczenia liczby slajdów przy scalaniu prezentacji?**

Brak sztywnych ograniczeń. Aspose.Slides obsługuje duże pliki, ale wydajność zależy od ich wielkości i zasobów systemowych. W przypadku bardzo dużych prezentacji zaleca się użycie 64‑bitowej JVM oraz przydzielenie odpowiedniej pamięci heap.

**Czy mogę scalać prezentacje z osadzonym wideo lub dźwiękiem?**

Tak, Aspose.Slides zachowuje treści multimedialne osadzone w slajdach, ale końcowa prezentacja może stać się znacznie większa.

**Czy czcionki zostaną zachowane przy scalaniu prezentacji?**

Tak. Czcionki użyte w źródłowych prezentacjach są zachowywane w pliku wynikowym, o ile są zainstalowane w systemie lub [osadzone](/slides/pl/androidjava/embedded-font/).