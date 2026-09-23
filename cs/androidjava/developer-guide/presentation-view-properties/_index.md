---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v Androidu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/androidjava/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý rozdělovač
- jedno zobrazení
- stav panelu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Android via Java pro úpravu formátů PPT, PPTX a ODP snímků — přizpůsobte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tato informace umožňuje aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, jako když byla prezentace naposledy uložena.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties) a jejich potomci, výčet [SplitterBarStateType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda by aplikace měla zobrazovat ikony při zobrazování obsahu osnovy v jakékoli oblasti obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda by svislý rozdělovač měl přecházet do minimalizovaného stavu, když je boční oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) určuje, zda uživatel upřednostňuje zobrazení jedné oblasti obsahu na celé obrazovce místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) určují stav, ve kterém by měl být zobrazen vodorovný nebo svislý posuvník. Vodorovný posuvník odděluje snímek od oblasti obsahu pod snímkem, svislý posuvník odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo boční oblasti snímku normálního zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnově INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřazené [getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška, pokud je podřazené [getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) normálního zobrazení, když má oblast proměnnou obnovovanou velikost (ani minimalizovanou, ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, pokud je podřazené restoredTop, výška, pokud je podřazené restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda by měla boční oblast obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat vlastnosti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

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

Aspose.Slides for Android via Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, že při otevření je přiblížení již nastaveno. Toto lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) prezentace. Metody [getSlideViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto článku ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) v Aspose.Slides. 

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Nastavte [View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
3. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).
   V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

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

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) pro přístup k nastavením zobrazení na úrovni celé prezentace. Metody [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) a [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) čtou nebo mění interval podkladové editační mřížky. Toto nastavení se vztahuje na celou prezentaci, nikoli na jednotlivý snímek. Rozestup mřížky je uváděn v bodech, kde 72 bodů odpovídá jedné palci. Používejte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující soubor `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtinového palce a výsledek uloží.

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

Mřížka se liší od [drawing guides](/slides/cs/androidjava/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodicí linky jsou individuálně umístěné vodorovné nebo svislé zarovnávací čáry. Přidání, přesunutí nebo vymazání vodicích linek nemění rozestup mřížky.

Jak mřížka, tak vodicí linky jsou pomůcky pro úpravy. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG nebo při promítání. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) pro přístup k nastavením zobrazení na úrovni celé prezentace. Metody [IViewProperties.getShowComments](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) a [IViewProperties.setShowComments](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) čtou nebo mění uloženou preferenci, zda se mají při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru zobrazovat komentáře.

Toto nastavení řídí pouze uloženou preferenci zobrazení. Nepřidává, neodstraňuje, neupravuje ani nerozhoduje komentáře. Skrytí komentářů zachovává jejich obsah, autory, pozice, odpovědi a stavy. Viz [Presentation Comments](/slides/cs/androidjava/presentation-comments/) pro operace, které mění samotné komentáře.

Níže uvedený příklad vyžaduje existující soubor `comments.pptx` obsahující komentáře. Vypíše aktuální nastavení viditelnosti, požádá o skrytí komentářů a uloží nový soubor PPTX, aniž by odstranil jakékoli komentáře. Také používá [IViewProperties.setLastView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) s [ViewType.SlideView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewtype/#SlideView) pro konfiguraci počátečního editačního zobrazení spolu s viditelností komentářů.

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

Toto nastavení neurčuje, zda jsou komentáře zahrnuty v exportech do PDF, HTML, obrázku, poznámek nebo podkladů. Příslušné možnosti exportu konfigurujte samostatně.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor řídí, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodicích linek (drawing guides) rozestup mřížky?**

Ne. Vodicí linky a rozestup mřížky jsou nezávislá nastavení. Vymazání linek ponechává uložený interval mřížky beze změny.

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

Nastavení zobrazení ([View settings](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--)) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nikoli na úrovni sekcí, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jediný soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými View Properties, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.