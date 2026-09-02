---
title: Správa kreslicích vodítek v prezentacích na Androidu
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/androidjava/drawing-guides/
keywords:
- kreslicí vodítko
- vodorovné vodítko
- svislé vodítko
- zarovnávací vodítko
- zobrazení snímku
- master snímku
- rozložení snímku
- master poznámek
- master letáku
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte vodorovná a svislá kreslicí vodítka v PowerPoint prezentacích pomocí Aspose.Slides pro Android přes Java."
---
## **Přehled**

Kreslicí vodítka jsou nastavitelná vodorovná a svislá čára, která uživatelům pomáhá konzistentně zarovnávat tvary při úpravě prezentace v PowerPointu. Jsou zvláště užitečná, když aplikace generuje prezentaci, která bude později ručně dolaďována: aplikace může uložit stejné pomůcky pro zarovnání, které by měli autoři při přidávání nebo přesouvání obsahu dodržovat.

Kreslicí vodítka jsou pomůcky pro úpravy, nikoli obsah snímku. Neobjeví se v prezentaci ani ve vykresleném výstupu. Aspose.Slides pro Android přes Java je zpřístupňuje prostřednictvím rozhraní [IDrawingGuidesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguidescollection/). Vodítko je reprezentováno objektem [IDrawingGuide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguide/) a má orientaci, pozici a barvu.

Pozice se měří v bodech od levého horního rohu příslušného snímku nebo masteru. Svislé vodítko používá vodorovnou souřadnici, obvykle mezi nulou a šířkou snímku. Vodorovné vodítko používá svislou souřadnici, obvykle mezi nulou a výškou snímku.

## **Přidání vodítek do zobrazení snímku**

Použijte [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) k řízení vodítek zobrazovaných při úpravě běžných snímků. Zavolejte [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidá jedno svislé vodítko vpravo od středu snímku a jedno vodorovné vodítko pod ním:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přístup ke kreslicím vodítkům**

Metody [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) a [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) poskytují přístup k existujícím vodítkům. Metody [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguide/#getPosition--) a [IDrawingGuide.getColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguide/#getColor--) vrací hodnoty, které lze také změnit pomocí odpovídajících metod nastavení.

Následující příklad načte vodítka ze zobrazení snímku z výše vytvořené prezentace:

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

## **Přidání vodítek do masteru a rozložení snímků**

Master snímku a každý z jeho rozložení může mít vlastní kolekci kreslicích vodítek. Pro master snímek použijte [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) a pro rozložení snímku použijte [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--).

Následující příklad přidá svislé vodítko k prvnímu masteru snímku a vodorovné vodítko k prvnímu rozložení snímku:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání vodítek do masterů poznámek a letáků**

Mastery poznámek a mastery letáků také podporují kreslicí vodítka. Použijte [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) a [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) k přístupu k jejich kolekcím. Pokud prezentace neobsahuje některý z těchto masterů, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) nebo [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) vytvoří výchozí master a vrátí jej.

Následující příklad přidá vodorovné vodítko do masteru poznámek a svislé vodítko do masteru letáků:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vymazání kreslicích vodítek**

Zavolejte [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) k odstranění všech vodítek z konkrétní kolekce. Vymazání jedné kolekce neovlivní vodítka uložená v jiném rozsahu.

Následující příklad vymaže vodítka ze zobrazení snímku a všech vodítek na masterech snímků, rozložení snímků, masteru poznámek a masteru letáků, aniž by vytvořil chybějící mastery:

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

**Objevují se kreslicí vodítka v prezentaci nebo exportovaných obrázcích?**

Ne. Kreslicí vodítka jsou pomocné pomůcky pro zarovnání při úpravách a nejsou vykreslována jako obsah prezentace.

**Lze kreslicí vodítko přidat přímo k jednotlivému běžnému snímku?**

Vodítka pro úpravy běžného snímku jsou uložena ve vlastnostech zobrazení snímku prezentace. Samostatné kolekce vodítek jsou k dispozici pro mastery snímků, rozložení snímků, mastery poznámek a mastery letáků.

**Jaké jednotky se používají pro pozice vodítek?**

Pozice jsou uváděny v bodech, kde 72 bodů odpovídá jednomu palci. Svislé pozice se měří od levého okraje a vodorovné pozice se měří od horního okraje.

**Odstraní vymazání kreslicích vodítek tvary nebo změní obsah snímku?**

Ne. Metoda [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) odstraňuje pouze vodítka ve vybrané kolekci. Tvary a další obsah snímku zůstávají beze změny.