---
title: Načtení a aktualizace vlastností zobrazení prezentace v Javě
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit vertikální rozdělovač
- jednoduché zobrazení
- stav pruhu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Java a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozložení, úroveň přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, jako bylo naposledy uloženo prezentací.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties) a jejich potomci, výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v jakékoli oblasti obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se má vertikální rozdělovač přichytit do zmenšeného stavu, když je boční oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) určuje, zda uživatel preferuje zobrazení jedné oblasti obsahu přes celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, může aplikace zobrazit jednu z oblastí obsahu v celé obrazovce.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) určují stav, ve kterém má být horizontální nebo vertikální pruh rozdělovače zobrazen. Horizontální pruh rozdělovače odděluje snímek od oblasti obsahu pod snímkem, vertikální pruh rozdělovače odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška, když je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) v normálním zobrazení, když má oblast proměnnou obnovenou velikost (ne ani zmenšenou, ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, když je podřízená restoredTop, výška, když je podřízená restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže uvedený příklad ukazuje, jak můžete získat přístup k vlastnostem [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Obnovit vlastnosti zobrazení prezentace
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Nastavení výchozí hodnoty přiblížení**

{{% alert color="info" %}} 
Aspose.Slides pro Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, že při otevření prezentace je přiblížení již nastaveno. Lze to provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) u [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) v Aspose.Slides.
{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) u [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/). V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i poznámek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Nastavení vlastností zobrazení prezentace
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Hodnota přiblížení v procentech pro zobrazení snímku
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Hodnota přiblížení v procentech pro zobrazení poznámek 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení rozestupu mřížky**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) pro přístup k nastavením zobrazení platným pro celou prezentaci. Metody [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iviewproperties/#getGridSpacing--) a [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) čtou nebo mění interval podkladové editační mřížky. Toto nastavení platí pro celou prezentaci, nikoli pro jednotlivý snímek. Rozestup mřížky je specifikován v bodech, kde 72 bodů odpovídá jednomu palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtiny palce a uloží výsledek.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mřížka se liší od [drawing guides](/slides/cs/java/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco náčrty jsou individuálně umístěné vodorovné nebo svislé vodící čáry. Přidávání, přesouvání nebo odstraňování náčrtů nemění rozestup mřížky.

Jak mřížka, tak náčrty jsou pomůcky při úpravách. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani při promítání. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na preferencích prohlížeče nebo editoru.

## **Zobrazit nebo skrýt komentáře při otevření prezentace**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) pro přístup k nastavením zobrazení platným pro celou prezentaci. Použijte [IViewProperties.getShowComments](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iviewproperties/#getShowComments--) a [IViewProperties.setShowComments](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) k načtení nebo změně uložené preference, zda mají být při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru zobrazeny komentáře.

Toto nastavení ovlivňuje jen uloženou preferenci zobrazení. Nepřidává, neodstraňuje, neupravuje ani neřeší komentáře. Skrytí komentářů zachovává jejich obsah, autory, pozice, odpovědi a stavy. Viz [Presentation Comments](/slides/cs/java/presentation-comments/) pro operace, které mění samotné komentáře.

Následující příklad vyžaduje existující `comments.pptx` obsahující komentáře. Vypíše aktuální nastavení viditelnosti, požádá o skrytí komentářů a uloží nový PPTX bez odstranění jakýchkoli komentářů. Také používá [IViewProperties.setLastView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iviewproperties/#setLastView-int-) s [ViewType.SlideView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewtype/#SlideView), aby nakonfiguroval počáteční zobrazení úprav spolu s viditelností komentářů.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Toto nastavení neurčuje, zda jsou komentáře zahrnuty do exportů PDF, HTML, obrázků, poznámek nebo letáků. Příslušné volby specifické pro export nakonfigurujte samostatně.

## **FAQ**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor řídí, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání náčrtů rozestup mřížky?**

Ne. Náčrty a rozestup mřížky jsou nezávislá nastavení. Vymazání náčrtů ponechá uložený interval mřížky beze změny.

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) jsou definována na úrovni prezentace ([Normal View]/[Slide View]), nikoli na úrovni sekce, takže jeden soubor parametrů se použije na celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílená. Prohlížečové aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jen jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.