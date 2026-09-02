---
title: Správa kreslicích vodítek v prezentacích v Javě
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/java/drawing-guides/
keywords:
- kreslicí vodítko
- horizontální vodítko
- vertikální vodítko
- zarovnávací vodítko
- zobrazení snímku
- hlavní snímek
- rozvržový snímek
- poznámkový hlavní snímek
- letákový hlavní snímek
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte horizontální a vertikální kreslicí vodítka v prezentacích PowerPoint pomocí Aspose.Slides pro Java."
---
## **Přehled**

Kreslicí vodítka jsou nastavitelná horizontální a vertikální čáry, které uživatelům pomáhají konzistentně zarovnávat tvary při úpravě prezentace v PowerPointu. Jsou zvláště užitečná, když aplikace generuje prezentaci, která bude později ručně vylepšována: aplikace může uložit stejné pomůcky pro zarovnání, které by měli autoři dodržovat při přidávání nebo přesouvání obsahu.

Kreslicí vodítka jsou pomůcky pro úpravy, nikoli obsah snímku. Nezobrazují se v režimu prezentace ani ve výstupním rendrování. Aspose.Slides for Java je zpřístupňuje prostřednictvím rozhraní [IDrawingGuidesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguidescollection/). Vodítko je reprezentováno pomocí [IDrawingGuide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguide/) a má orientaci, pozici a barvu.

Pozice se měří v bodech od levého horního rohu příslušného snímku nebo nadržené šablony. Vertikální vodítko používá horizontální souřadnici, typicky mezi nulou a šířkou snímku. Horizontální vodítko používá vertikální souřadnici, typicky mezi nulou a výškou snímku.

## **Přidání vodítek do zobrazení snímku**

Použijte [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) k řízení vodítek zobrazovaných při úpravě běžných snímků. Zavolejte [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidá jedno vertikální vodítko napravo od středu snímku a jedno horizontální vodítko pod ním:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přístup ke kreslicím vodítkům**

Metody [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguidescollection/#getCount--) a [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) poskytují přístup k existujícím vodítkům. Metody [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguide/#getPosition--), a [IDrawingGuide.getColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguide/#getColor--) vracejí hodnoty, které lze také změnit pomocí odpovídajících metod setter.

Následující příklad načte vodítka zobrazení snímku z výše vytvořené prezentace:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Přidání vodítek do hlavního a rozvržových snímků**

Hlavní snímek a každý jeho rozvržový snímek mohou mít vlastní sbírky kreslicích vodítek. Pro hlavní snímek použijte [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/#getDrawingGuides--), pro rozvržový snímek [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--).

Následující příklad přidá vertikální vodítko na první hlavní snímek a horizontální vodítko na první rozvržový snímek:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání vodítek do poznámkových a letákových hlav**

Poznámkové hlavní snímky a letákové hlavní snímky také podporují kreslicí vodítka. Použijte [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) a [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) k přístupu k jejich sbírkám. Pokud prezentace neobsahuje některý z těchto hlavních snímků, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) nebo [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) vytvoří výchozí hlavní snímek a vrátí jej.

Následující příklad přidá horizontální vodítko do poznámkového hlavního snímku a vertikální vodítko do letákového hlavního snímku:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vymazání kreslicích vodítek**

Zavolejte [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguidescollection/#clear--) pro odebrání všech vodítek z konkrétní sbírky. Vymazání jedné sbírky neovlivní vodítka uložená v jiném rozsahu.

Následující příklad vymaže vodítka zobrazení snímku a všechna vodítka na hlavních snímcích, rozvržových snímcích, poznámkovém hlavním snímku a letákovém hlavním snímku bez vytváření chybějících hlav:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Zobrazují se kreslicí vodítka v režimu prezentace nebo v exportovaných obrázcích?**

Ne. Kreslicí vodítka jsou pomůcky pro zarovnání při úpravách a nejsou vykreslována jako obsah prezentace.

**Lze kreslicí vodítko přidat přímo k jednotlivému normálnímu snímku?**

Vodítka pro úpravy normálního snímku jsou uložena v vlastnostech zobrazení snímku prezentace. Samostatné sbírky vodítek jsou k dispozici pro hlavní snímky, rozvržové snímky, poznámkové hlavní snímky a letákové hlavní snímky.

**Jaké jednotky se používají pro pozice vodítek?**

Pozice jsou uváděny v bodech, kde 72 bodů odpovídá jednomu palci. Vertikální pozice se měří od levého okraje a horizontální pozice od horního okraje.

**Odstraňuje vymazání kreslicích vodítek tvary nebo mění obsah snímku?**

Ne. Metoda [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idrawingguidescollection/#clear--) odstraňuje pouze vodítka ve vybrané sbírce. Tvary a další obsah snímku zůstávají beze změny.