---
title: "Prezentáció hiperhivatkozások kezelése PHP-ben"
linktitle: "Hiperhivatkozások kezelése"
type: docs
weight: 20
url: /hu/php-java/manage-hyperlinks/
keywords:
- "URL hozzáadása"
- "hiperhivatkozás hozzáadása"
- "hiperhivatkozás létrehozása"
- "hiperhivatkozás formázása"
- "hiperhivatkozás eltávolítása"
- "hiperhivatkozás frissítése"
- "szöveges hiperhivatkozás"
- "dia hiperhivatkozás"
- "alakzat hiperhivatkozás"
- "kép hiperhivatkozás"
- "videó hiperhivatkozás"
- "módosítható hiperhivatkozás"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével, PHP példákkal."
---
## **Bevezetés**

A hiperhivatkozás a bemutató tartalmát egy weboldalhoz vagy a bemutató egy másik helyéhez kapcsolja. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például a tartalomjegyzékből.

Az Aspose.Slides for PHP via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, illetve hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szövegkeret szintjén. Feltételezik, hogy a PHP/Java Bridge és az Aspose.Slides PHP wrapper inicializálva van. A PHP referenciaoldallal nem rendelkező API tagok a háttérben lévő Java API-ra mutatnak.

{{% alert color="info" title="Note" %}}
A bemutatókat szerkesztheti a [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/hu/editor) segítségével is.
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t adhat szöveghez, alakzathoz vagy média kerethez. A hiperhivatkozást tartalmazó elem határozza meg a kattintható területet: egy szövegrész a kijelölt szöveget kapcsolja, míg egy alakzat vagy keret az egész diára vonatkozó objektumot.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveget egy weboldalra hivatkozáshoz adja át egy [Hyperlink](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/) objektumot a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/sethyperlinkclick/) metódusával, ahogyan az alább látható. Csak ez a szövegrész lesz kattintható.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **URL hiperhivatkozások hozzáadása alakzatokhoz és média keretekhez**

Alakzat vagy keret kattinthatóvá tételéhez hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/sethyperlinkclick/) metódust. A hiperhivatkozás az objektumhoz tartozik, nem a benne lévő szövegrészhez.

Ugyanez a megközelítés vonatkozik kép, hang és videó keretekre: rendelje hozzá a hiperhivatkozást a kerethez, és szükség esetén hívja meg a [setTooltip](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/settooltip/) metódust.

Az alábbi példa egy téglalapot tesz kattinthatóvá:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Belső hiperhivatkozásokkal az olvasó a tartalomjegyzékből egy adott diára ugorhat. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) metódust használja, hogy az első dia „Page 2” szövegét a második diára linkelje.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hiperhivatkozások formázása**

### **Szín**

A [Hyperlink](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/) [setColorSource](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/setcolorsource/) metódusa határozza meg, hogy a hiperhivatkozás a bemutató hiperhivatkozási színét vagy a szövegrész formázását használja-e. Egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; régebbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szöveggel, a második az alapértelmezett hiperhivatkozási színnel.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Hang**

A hiperhivatkozás aktiváláskor lejátszhat egy hangot, vagy leállíthat egy már játszott hangot. A következő metódusokkal állíthatja be ezeket a viselkedéseket:

- [Hyperlink::setSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/setsound/) adja meg a hiperhivatkozáshoz tartozó hangot.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/setstopsoundonclick/) szabályozza, hogy a hiperhivatkozás aktiválása megállítsa‑e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és az első dián egy gombhoz rendeli. A gomb kattintása lejátsza a hangot és a következő diára navigál. A dián egy másik alakzat a kattintáskor leállítja az előző hangot, anélkül hogy navigálna.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Hiperhivatkozás hangjának kinyerése**

Az alábbi példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/getsound/) és [getBinaryData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audio/getbinarydata/) metódusok segítségével beolvassa az első alakzat hiperhivatkozás hangját memóriába.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Eszköztipp és interakciós beállítások**

A hiperhivatkozás szöveghez vagy alakzathoz rendelve a következő [Hyperlink](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/) metódusok hívhatók meg:

- [setTooltip](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/settooltip/) beállítja a megjelenő szöveget, amely a néző számára tippként szolgál a linkhez.
- [setTargetFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/settargetframe/) meghatározza a célt keretet egy szülő HTML keretcsoportban, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/sethistory/) szabályozza, hogy a link aktiválása felvegye‑e a célpontot a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/sethighlightclick/) szabályozza, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a bemutatókból**

A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) segítségével gyűjtheti be a hiperhivatkozás‑tárolókat, beleértve a szövegrész‑hivatkozásokat is, mielőtt módosítaná őket. Az alábbi példa mindkét aktivációs típust eltávolítja az első diáról. Egyetlen típus eltávolításához hívja csak a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metódust; egy kattintási művelet eltávolítása nem távolítja el a mouse‑over megfelelőjét.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Feltétlen eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) mindkét aktivációs típust egy hívással eltávolítja a kijelölt hatókörben. Szelektív takarításhoz és a master‑ek, elrendezések és jegyzetek lefedéséhez lásd a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás‑leltár készítése**

A bemutató terjesztése előtt készítsen leltárt az interaktív műveletekről és a webes hivatkozásokról egyaránt. A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy egyszerű URL‑lista. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) eredményét minden tárolón. Ezek függetlenek: ugyanaz a tároló mindkét műveletet kiexponálhatja, így egy teljes jelentés akár két sort is igényel egy tárolónként.

Csak alakzatra vonatkozó hiperhivatkozások vizsgálata kihagyhatja a szövegrészhez csatolt linkeket. Inkább a megfelelő hatókört kérdezze le, és őrizze meg a visszakapott tárolókat a későbbi frissítéshez vagy eltávolításhoz.

### **Bemutató, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/) osztály a [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/gethyperlinkqueries/), a [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) és a [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/gethyperlinkqueries/) révén érhető el. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) kattintási műveletet tartalmazó tárolókat ad vissza.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) mouse‑over műveletet tartalmazó tárolókat ad vissza.
- [getAnyHyperlinks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) bármelyik vagy mindkét műveletet tartalmazó tárolókat ad vissza.

Az alábbi példa egy `hyperlink-audit-input.pptx` fájlt hoz létre, amely egy külső kattintási linket, egy fájl mouse‑over linket, belső diánavigációt, egy szöveg‑mouse‑over linket és egy makró‑műveletet tartalmaz. A példában egyik művelet sem kerül végrehajtásra. Ugyanaz a három lekérdezés minden hatókörben működik; a számok tárolókat jelölnek, nem a műveletek összeszámát. A szövegkeret hatókör kihagyja a körülvevő alakzat saját linkjeit.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ebben a példában a bemutató‑ és dia‑lekérdezések három kattintási, két mouse‑over és három vegyes tárolót jelentenek. A szövegkeret lekérdezés egy tárolót ad minden kategóriában.

### **Műveletek és célpontok osztályozása**

Az [Hyperlink::getActionType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/getactiontype/) segítségével értelmezze a műveletet, mielőtt a célpontot elemzi. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkactiontype/) értékek a webnavigáción túl is terjednek:

| Értékek | Jelentés audit során |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | A jelenlegi előadás befejezése vagy egy egyéni előadás indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik bemutató megnyitása; külön kezelje a webes URL‑ktől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Olvassa ki a külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/getexternalurl/) metódussal, a belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/gettargetslide/) segítségével. Belső műveletek és beépített parancsok esetén lehet, hogy nincs külső URL; egy üres URL nem jelenti, hogy a tárolónak nincs művelete. Tárolja a [getExternalUrlOriginal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) által visszaadott értéket, ha az eltér a normalizált URL‑től, és adja hozzá a [getTooltip](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlink/gettooltip/) által visszaadott eszköztippet, ha elérhető.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

Az alábbi PHP példa beolvassa a meglévő bemutatót (használja a fent létrehozott fájlt), kiírja a `hyperlink-audit.json` fájlt, alkalmaz egy szabályzatot, elmenti a `hyperlink-sanitized.pptx` fájlt, majd újra megnyitja, hogy ellenőrizze mindkét aktivációs típust. A tárolókat a módosítás előtt gyűjti össze, és referenciához hasonlított egyenlőséget használ, hogy ne dolgozzon fel egy tárolót kétszer. A bemutató‑lekérdezések a szokásos diákra vonatkoznak; csomagszintű leltárhoz explicit módon lekérdezi a master‑eket, elrendezéseket, jegyzeteket és a jegyzet‑ illetve kézivétel‑master‑eket, ha jelen vannak.

A jelentés egy 1‑től induló diaindexet és a [getSlideId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getSlideId--) értéket tartalmaz, ahol elérhető. Az [ISlideComponent::getSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecomponent/#getSlide--) biztosítja a tulajdonló diát a támogatott tárolókhoz. A master‑ek, elrendezések és jegyzetek nem rendelkeznek szokásos diaindexszel, ezért a hatókörük szerint azonosíthatók. Az alakzat‑tárolókat és a szövegrész‑formázási tárolókat külön jelölik; más tárolótípusok megtartják a futásidejű típusnevüket. Minden tároló kap egy jelentés‑lokális azonosítót, hogy a két művelet összekapcsolható legyen. A jelentés a PHP enumeráció által definiált egészállandókat tárolja művelettípusként.

Ez a szándékosan szigorú alkalmazási szabályzat csak abszolút HTTPS URL‑ket és érvényes belső dia‑célpontokat engedélyez. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások szabályzati döntések, nem az Aspose.Slides biztonságának megítélése. A HTTPS önmagában nem garantálja a megbízhatóságot: adjon hozzá host‑fehérlistákat és egyéb ellenőrzéseket a saját alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ket ellenőrzik. A példa metaadat‑auditot végez hivatkozás követése vagy művelet‑végrehajtás nélkül.

Javításhoz a tároló [getHyperlinkManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metódusokat. Itt a tiltott külső kattintási linkeket egy rögzített HTTPS céloldallal helyettesítik; a többi tiltott kattintás és a tiltott mouse‑over műveletek önállóan eltávolításra kerülnek. A `$replaceExternalClicks` változót `false`‑ra állítva minden szabálysértés eltávolításra kerül. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés exportálási jelzője egy konzervatív PDF‑ellenőrzési szabályzatot használ: jelöli a mouse‑over műveleteket és minden olyan elemet, amely nem egy külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottként. Ez egy felülvizsgálati tipp, nem képesség‑teszt vagy garancia arra, hogy a nem jelölt linkek megmaradnak az exportálás során. A támogatott [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/php-java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, az export‑opcióktól és a megjelenítőtől függően. A raszteres [képek](/slides/hu/php-java/convert-powerpoint-to-png/) és [videók](/slides/hu/php-java/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; ezeknél minden műveletet jelöljön meg audit során.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

A fenti bemenettel a jelentés öt művelet‑sort tartalmaz. A fájl mouse‑over link és a makró kattintás eltávolításra kerül, míg a HTTPS linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet írt ki. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítési ágat is teszteli. Egy engedélyezett kattintással és tiltott mouse‑overrel rendelkező tároló megtartja a kattintási műveletét.

Ez a szelekciós takarítás eltér a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) működésétől, amely a kiválasztott hatókörben mindkét aktivációs típust eltávolítja szabályzat függetlenül. Itt a ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projekteket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem validálja az exportált PDF‑ vagy HTML‑fájlokat.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPoint szekciók diákat csoportosítanak, de egy belső hiperhivatkozás egyedi diát céloz. Egy szekcióra való navigáláshoz linkelje az első diát az adott szekcióban.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia‑ és elrendezés‑elemek támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő master‑t vagy elrendezést használják.

**Megmaradnak-e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; raszteres képek és videók nem. Lásd a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részben az exportálási szempontokat.