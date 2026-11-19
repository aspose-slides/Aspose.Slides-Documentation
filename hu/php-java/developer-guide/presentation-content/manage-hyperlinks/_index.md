---
title: Prezentációs hiperhivatkozások kezelése PHP-ben
linktitle: Hiperhivatkozások kezelése
type: docs
weight: 20
url: /hu/php-java/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével, PHP példákkal."
---
## **Bevezetés**

A hiperhivatkozás összeköti a bemutató tartalmát egy weboldallal vagy a bemutatón belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for PHP via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését, valamint eltávolításukat. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, és hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szövegkeret szintjén. Feltételezik, hogy a PHP/Java Bridge és az Aspose.Slides PHP wrapper inicializálva van. A PHP hivatkozási oldal nélküli API tagok az alapul szolgáló Java API-ra mutatnak.

{{% alert color="info" title="Note" %}}
Ingyenesen szerkesztheti a bemutatókat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **URL hiperláncok hozzáadása**

Weboldal‑URL‑t adhat szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrész a kijelölt szöveget, míg egy alakzat vagy keret a dia objektumát linkeli.

A relatív hiperhivatkozásokat tartalmazó bemutatók esetén tekintse meg a [A hiperhivatkozás bázis kezelése](/slides/hu/php-java/presentation-properties/#manage-the-hyperlink-base) oldalt a dokumentumszintű alap beolvasásához, módosításához vagy törléséhez.

### **URL hiperláncok hozzáadása szöveghez**

A szövegrész weboldalra történő hivatkozásához adjon át egy [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) a szövegdarab [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) metódusának, az alább látható módon. Csak az adott szövegrész lesz kattintható.

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

### **URL hiperláncok hozzáadása alakzathoz és média keretekhez**

Hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) metódust a téglalapra, hogy annak teljes területe kattintható legyen. Használja a [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) metódust, hogy a felhasználó a téglalap fölé húzva egy tippet lásson a célpontról. Mindkét módszer alkalmazható kép‑, hang‑ és videókeretekre is.

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

A belső hiperhivatkozások lehetővé teszik a felhasználók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. A következő példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) metódust használja, hogy az első dia “Page 2” szövegét a második diára linkelje.

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

Megváltoztathatja a linkelt szöveg színét, lejátszhat vagy leállíthat egy hangot, amikor a felhasználó aktiválja a linket, valamint beállíthatja a hover‑nél megjelenő tooltip‑et.

### **Szín**

A [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) metódus a [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/)‑nél határozza meg, hogy a hiperhivatkozás a bemutató hiperhivatkozás‑színét vagy a szövegrész formázását használja‑e. Egy egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltés‑színét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Ebben a példában a [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) az első linket a szövegrész piros kitöltésével látja el. A második link a bemutató hiperhivatkozás‑színét használja.

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

Egy hiperhivatkozás lejátszhat egy hangot aktiváláskor, vagy leállíthat egy már futó hangot. Az alábbi módszerekkel állíthatja be ezeket a viselkedéseket:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) meghatározza a hiperhivatkozáshoz társított audiót.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) szabályozza, hogy a hiperhivatkozás aktiválása leállítsa‑e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az első dián lévő gomb a [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) metódust használja, hogy a `sampleaudio.wav` fájlt játssza le, amikor a felhasználó a továbblépéshez kattint. A második dián egy külön gomb a [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) metódust használja a lejátszás leállításához, miközben a felhasználó a dián marad.

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

Az alábbi példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) és [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) metódusokkal a első alakzat hiperhivatkozás‑audióját memóriába olvassa.

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

### **Értesítési tippek és interakciós beállítások**

A [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) következő metódusait hívhatja meg egy hiperhivatkozás szöveghez vagy alakzathoz való hozzárendelése után:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) beállítja azt a szöveget, amelyet a néző tippként jeleníthet meg a linkhez.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) megadja a célt‑keretet egy szülő HTML frameset‑en belül, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) szabályozza, hogy a link aktiválása felvehesse‑e a célját a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) szabályozza, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a bemutatókból**

A [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) használatával gyűjthet hiperhivatkozás‑konténereket, beleértve a szövegrész‑linkeket is, mielőtt módosítaná őket. Az alábbi példa eltávolítja mindkét aktiválási típust az első diáról. Egyetlen típus eltávolításához csak a [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metódust hívja; a kattintási művelet eltávolítása nem távolítja el az egér‑over megfelelőjét.

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

Feltétlen eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) mindkét aktiválási típust egy hívással törli a kiválasztott hatókörben. Szelektív takarítás és a master‑ek, elrendezések és jegyzetek lefedése érdekében tekintse meg a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

### **Hiperhivatkozások törlése a SmartArt szöveg cseréje előtt**

Amikor egy meglévő SmartArt csomópontban egy bekezdést cserél, a szövegrészek törlése régi hiperhivatkozást hagyhat működésben. A bekezdést a [SmartArtNode::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/gettextframe/) metódussal kapja meg. A részek törlése előtt hívja meg a [getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/)‑t a csomópont alakzatának szövegkeretén, majd a visszakapott objektumon a [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)‑t. Ez eltávolítja az adott keretben lévő minden hiperhivatkozást, beleértve a többi bekezdés linkjeit is.

A példa feltételezi, hogy a `SmartArtHyperlink.pptx` első diáján a harmadik alakzat egy SmartArt grafika. A negyedik csomópont első bekezdését cseréli le. Ebben a bemutatóban a csomópont első alakzata jeleníti meg azt a bekezdést.

A két részlet hozzáadása után a példa a [getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/)‑tel olvassa ki a tényleges formázást. Ezen a formázáson a [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) visszaadja az első részlet új hiperhivatkozását és `null`‑t a másodiknak.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Portion;
use aspose\slides\Presentation;

$presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $smartArt = $slide->getShapes()->get_Item(2);
    $node = $smartArt->getAllNodes()->get_Item(3);
    $paragraph = $node->getTextFrame()->getParagraphs()->get_Item(0);

    $node->getShapes()->get_Item(0)->getTextFrame()->getHyperlinkQueries()->removeAllHyperlinks();
    $paragraph->getPortions()->clear();

    $link = new Portion("New reference");
    $link->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://example.com/new"));
    $paragraph->getPortions()->add($link);
    $text = new Portion(" (updated)");
    $paragraph->getPortions()->add($text);

    echo java_values($link->getPortionFormat()->getEffective()->getHyperlinkClick()->getExternalUrl()), PHP_EOL; // https://example.com/new
    var_dump(java_is_null($text->getPortionFormat()->getEffective()->getHyperlinkClick())); // bool(true): a második résznek nincs hiperhivatkozása.
} finally {
    $presentation->dispose();
}
```

## **Teljes hiperhivatkozás‑inventár felépítése**

A bemutató terjesztése előtt készítsen inventárt a interaktív műveleteiről és a web‑linkjeiről. A [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egyszerű URL‑string listát. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) minden egyes konténeren. Ezek függetlenek: egy konténer mindkét műveletet is tartalmazhat, ezért egy teljes jelentéshez akár két sorra is szükség lehet konténerenként.

Ha csak alakzati szintű hiperhivatkozásokat kérdez le, könnyen kimaradhatnak a szövegrészekhez csatolt linkek. Lekérdezés helyett a megfelelő hatókört válassza, és őrizze meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa a műveleteiket.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) osztály a [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) és a [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/)‑n keresztül érhető el. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) visszaadja a kattintási művelettel rendelkező konténereket.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) visszaadja az egér‑over művelettel rendelkező konténereket.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) visszaadja az egyiket vagy mindkettőt tartalmazó konténereket.

Ez a példa kattintási és egér‑over műveleteket rendeli egy alakzathoz és a szövegéhez, valamint egy makró‑műveletet egy külön gombhoz. Összehasonlítja a [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) által visszaadott konténerek számát az egyes aktiválási típusok számaival. Egy szövegkeret‑lekérdezés csak a szövegben lévő linkeket számolja. A körülvevő alakzat saját műveletei a dia‑ és prezentáció‑lekérdezésekben is megjelennek.

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

Ebben a példában a prezentációs és dia‑lekérdezések három kattintási konténert, két egér‑over konténert és három, bármelyik művelettel rendelkező konténert jelentenek. A szövegkeret‑lekérdezés egy‑egy konténert jelent mindhárom kategóriában.

### **Műveletek és célok osztályozása**

Használja a [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/)‑t, hogy a cél meghatározása előtt értelmezze a műveletet. A [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is kiterjednek:

| Értékek | Jelentés egy audit számára |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL-t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyéni bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön kell ellenőrizni a webes URL‑ekkel szemben. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy egy ismeretlen művelet, amely felülvizsgálatot igényel. |

Olvassa be a külső célokat a [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/)‑val, a specifikus belső célokat pedig a [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/)‑val. Belső műveletek és beépített parancsok esetén lehet, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs művelete. Tartsa meg a [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) által visszaadott értéket, ha eltér a normalizált URL‑től, és adja hozzá a [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) által visszaadott tooltip‑et, ha elérhető.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

Ez a példa megnyitja a korábbi példában létrehozott prezentációt, és minden műveletről egy JSON‑rekordot ír. A [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) segítségével gyűjti a normál diák, master‑ek, elrendezések és jegyzetek konténereit, beleértve a jegyzet‑ és kézikönyv‑master‑eket, ha jelen vannak. Referenciális egyenlőséget használ az egyes konténerek egyszeri számlálásához, alkalmazza az alább leírt politikát, majd újra megnyitja a mentett prezentációt, hogy ellenőrizze a kattintási és egér‑over műveleteket.

A jelentés egy‑alapú diák indexet és a [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) értéket tárolja, ahol elérhető. A [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) adja vissza a tulajdonos diát a támogatott konténerekhez. A master‑ek, elrendezések és jegyzetek nem rendelkeznek hagyományos dia‑indexszel, és hatókörük szerint azonosítók. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön címkézi; a többi konténer típusa megtartja futásidejű típusnevét. Minden konténer kap egy jelentés‑lokális azonosítót, hogy a két művelet összekapcsolható legyen. A jelentés a művelettípusokat a PHP felsorolásban definiált egészérték‑állandókként tárolja.

Ez a szándékosan szigorú alkalmazás‑politika csak abszolút HTTPS URL‑eket és érvényes belső dia‑célokat engedélyez. Tiltja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és más URL‑sémákat. Ezek a elutasítások politikai döntések, nem az Aspose.Slides biztonsági ítélete. Az HTTPS‑nek önmagában nem elég a bizalomhoz: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket a saját alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑eket ellenőrizzük. A példa a metaadatokat auditálja anélkül, hogy a hivatkozásokat követné vagy a műveleteket végrehajtaná.

Javításra a konténer [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), a [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metódusokat. Itt a tiltott külső kattintási hivatkozásokat egy fix HTTPS landoló oldalra cserélik; a többi tiltott kattintás és tiltott egér‑over művelet külön‑külön eltávolításra kerül. A `$replaceExternalClicks` változót `false`‑ra állítva az összes politikai megsértés eltávolítható. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés export‑jelzője konzervatív PDF‑áttekintési politikát alkalmaz: egér‑over műveleteket és minden, ami nem külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottnak jelöli. Ez csak egy áttekintési útmutató, nem képesség‑teszt vagy garancia arra, hogy a nem jelölt linkek exportáláskor megmaradnak. A támogatott [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/php-java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, az export‑opcióktól és a megjelenítőtől függően. A raszteres [images](/slides/hu/php-java/convert-powerpoint-to-png/) és [video](/slides/hu/php-java/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; ilyen kimenetek auditálásakor minden műveletet jelöljön meg.

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

A fent létrehozott bemenet alapján a jelentés öt művelet‑sort tartalmaz. A fájl‑egér‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső diánavigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítő ágat is teszteli. Egy olyan konténer, amelynek engedélyezett kattintása és tiltott egér‑overje van, megtartja a kattintási műveletet.

Ez a szelektív takarítás eltér a [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)‑től, amely a kiválasztott hatókörön belül mindkét aktiválási típust eltávolítja a politika tekintetében. Az itt végzett ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA projektek, OLE objektumok vagy egyéb aktív tartalmak, és nem ellenőrzi a kiexportált PDF‑ vagy HTML‑fájlokat.

## **GYIK**

**Hogyan lehet egy szekcióhoz vagy annak első diajához linkelni?**

A PowerPoint szekciók a diák csoportosítására szolgálnak, de egy belső hiperhivatkozás egy adott diát céloz. Egy szekcióhoz való navigáció létrehozásához a szekció első diájához kell linkelni.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és az elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő master‑t vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videó nem képesek interaktív hiperhivatkozásokat megőrizni. Lásd a [Hiperhivatkozások jelentése, tisztítása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt a exportálási szempontokról.