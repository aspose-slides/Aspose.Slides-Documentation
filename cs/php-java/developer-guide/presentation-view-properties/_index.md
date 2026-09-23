---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v PHP
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/php-java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý rozdělovač
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro PHP přes Java, pomocí nichž můžete přizpůsobit formáty PPT, PPTX a ODP snímků – upravit rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uloženo.

Byla přidána metoda [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNormalViewProperties), která poskytuje přístup k vlastnostem normálního zobrazení prezentace.  

Byly přidány třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties) a jejich potomci a výčet [SplitterBarStateType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType) byl přidán.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v kterékoli oblasti obsahu v režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) určují, zda má svislý rozdělovač přejít do minimalizovaného stavu, když je boční oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) a [setPreferSingleView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) určuje, zda uživatel preferuje zobrazit celou oblast obsahu v jednom okně místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) určují stav, ve kterém má být zobrazen vodorovný nebo svislý rozdělovač. Vodorovný rozdělovač odděluje snímek od oblasti obsahu pod snímkem, svislý rozdělovač odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Maximized) a [SplitterBarStateType::Restored](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) a [getRestoredTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties#getRestoredTop) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro [SplitterBarStateType::Restored](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SplitterBarStateType/#Restored) použita hodnota pro [getVerticalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) odpovídajícím způsobem.

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je podřízená metodě [getRestoredTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), výška, když je podřízená metodě [getRestoredLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) v normálním zobrazení, pokud je oblast obnovitelné proměnné velikosti (ne ani minimalizovaná, ani maximalizovaná).  

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) určuje velikost oblasti snímku (šířka, když je podřízená restoredTop, výška, když je podřízená restoredLeft).  

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.  

Níže uvedený příklad ukazuje, jak můžete získat vlastnosti [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) pro prezentaci.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Obnovit vlastnosti zobrazení prezentace
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Nastavit výchozí hodnotu přiblížení**
{{% alert color="info" %}} 

Aspose.Slides pro PHP přes Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, že při otevření je přiblížení již nastavené. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) lze nastavit programově. V tomto článku si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) prezentace [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) v Aspose.Slides.

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
2. Nastavte [View Properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ViewProperties) prezentace [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
3. Uložte prezentaci jako soubor [PPTX ](https://docs.fileformat.com/presentation/pptx/).  
   V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

```php
  $presentation = new Presentation();
  try {
    # Nastavení vlastností zobrazení prezentace
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Hodnota přiblížení v procentech pro zobrazení snímku
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Hodnota přiblížení v procentech pro zobrazení poznámek

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Nastavit rozestup mřížky**

Použijte [Presentation::getViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getViewProperties) k přístupu k nastavením zobrazení na úrovni celé prezentace. Metody [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/#getGridSpacing) a [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/#setGridSpacing) čtou nebo mění interval podkladové editační mřížky. Toto nastavení se vztahuje na celou prezentaci, ne na jednotlivý snímek. Rozestup mřížky je udáván v bodech, kde 72 bodů odpovídá jednomu palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtinového palce a uloží výsledek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mřížka se liší od [drawing guides](/slides/cs/php-java/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodící čáry jsou jednotlivě umístěné horizontální nebo vertikální zarovnávací čáry. Přidání, přesunutí nebo vymazání vodicích čar nemění rozestup mřížky.

Jak mřížka, tak vodicí čáry jsou pomocí při editaci. Nejsou vykresleny jako obsah snímku v PDF, obrázcích, SVG ani při promítání. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Zobrazit nebo skrýt komentáře při otevření prezentace**

Použijte [Presentation::getViewProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getviewproperties/) k přístupu k nastavením zobrazení na úrovni celé prezentace. Použijte [ViewProperties::getShowComments](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/getshowcomments/) a [ViewProperties::setShowComments](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/setshowcomments/) k přečtení nebo změně uložené preference, zda mají být při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru zobrazeny komentáře.

Toto nastavení řídí pouze uloženou preferenci zobrazení. Nepřidává, neodstraňuje, neupravuje ani neřeší komentáře. Skrytí komentářů zachovává jejich obsah, autory, umístění, odpovědi a stav. Viz [Presentation Comments](/slides/cs/php-java/presentation-comments/) pro operace měnící samotné komentáře.

Následující příklad vyžaduje existující `comments.pptx` obsahující komentáře. Vypíše aktuální nastavení viditelnosti, požádá o skrytí komentářů a uloží nový PPTX bez odebrání jakýchkoli komentářů. Také používá [ViewProperties::setLastView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/setlastview/) s [ViewType::SlideView](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewtype/#SlideView) k nastavení počátečního zobrazení editace spolu s viditelností komentářů.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Toto nastavení neurčuje, zda jsou komentáře zahrnuty do exportu do PDF, HTML, obrázku, poznámek nebo letáků. Příslušné možnosti specifické pro export nastavte samostatně.

## **Často kladené otázky**

**Proč mřížka není viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale zobrazení mřížky řídí editor. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Změní vymazání vodicích čar rozestup mřížky?**

Ne. Vodicí čáry a rozestup mřížky jsou nezávislá nastavení. Vymazání vodicích čar nemění uložený interval mřížky.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

Nastavení [View settings](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getviewproperties/) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/php-java/aspose.slides/viewproperties/getslideviewproperties/)), nikoli na úrovni sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různá stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými View Properties, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getviewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.