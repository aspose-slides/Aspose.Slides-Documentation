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

A hiperhivatkozás összeköti a bemutató tartalmát egy weboldallal vagy a bemutatón belüli helyre. A PowerPointban a hiperhivatkozások általában két célt szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy médiakeretből.
* Egy másik diára navigálás, például egy tartalomjegyzékből.

Az Aspose.Slides for PHP via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk szabályozását, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, és hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szövegkeret szintjén. Feltételezzük, hogy a PHP/Java Bridge és az Aspose.Slides PHP wrapper inicializálva van. Azok az API tagok, amelyeknek nincs PHP hivatkozási oldala, az alapjául szolgáló Java API-ra mutatnak.

{{% alert color="info" title="Note" %}}
[ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/editor) segítségével is szerkesztheted a bemutatókat.
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Egy weboldal URL-jét szöveghez, alakzathoz vagy médiakerethez rendelheted. Az elem, amelyhez a hiperhivatkozást rendelsz, meghatározza a kattintható területet: egy szövegrészlet a kijelölt szövegre mutat, míg egy alakzat vagy keret a diaobjektumra hivatkozik.

Relatív hiperhivatkozásokat tartalmazó bemutatók esetén lásd a [A hiperhivatkozás alapjának kezelése](/slides/hu/php-java/presentation-properties/#manage-the-hyperlink-base) című oldalt a dokumentumszintű alap olvasásához, módosításához vagy törléséhez.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalra való hivatkozásához egy [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) objektumot kell átadni a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) metódusának, ahogy az alább látható. Csak az a szövegrész lesz kattintható.

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz és médiakeretekhez**

A shape vagy keret kattinthatóvá tételéhez hívd meg a [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem egy benne lévő szövegrészhez.

Ez a megközelítés képekre, hang- és videokeretekre is érvényes: rendeld hozzá a hiperhivatkozást a kerethez, és szükség esetén hívd meg a [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) metódust.

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

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) metódust használja a „Page 2” szöveg (az első dián) összekapcsolásához a második diával.

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

A [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) metódus a [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) osztályban meghatározza, hogy a hiperhivatkozás a bemutató hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egy egyéni szövegszín alkalmazásához válaszd ki a [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) lehetőséget, és állítsd be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a korábbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szövegtöltést használ, míg a második megőrzi az alapértelmezett hiperhivatkozás színt.

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

Egy hiperhivatkozás aktiváláskor lejátszhat egy hangot, vagy leállíthat egy már lejátszott hangot. Az alábbi módszerekkel állíthatod be ezeket a viselkedéseket:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) megadja a hiperhivatkozáshoz társított hangot.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) vezérli, hogy a hiperhivatkozás aktiválásakor leálljon-e az előző hang.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz rendeli az első dián. A gombra kattintva lejátszódik a hang és a következő diára navigál. Egy második alakzat ugyanazon a dián kattintáskor leállítja az előző hangot, anélkül, hogy navigációs műveletet végezne.

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

Az alábbi példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) és [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) metódusok segítségével beolvassa az első alakzat hiperhivatkozás hangját memóriába.

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

### **Buboréksúgó és interakció beállítások**

Miután hiperhivatkozást rendeltél szöveghez vagy alakzathoz, az alábbi [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) metódusokat hívhatod meg:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) beállítja a szöveget, amelyet a megtekintő a hivatkozás tippjeként jeleníthet meg.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) megadja a célt keretet egy szülő HTML kerettömbön belül, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) vezérli, hogy a hivatkozás aktiválása hozzáadja-e a célját a megtekintett hiperhivatkozások listájához.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) vezérli, hogy a hiperhivatkozás kattintáskor kiemelésre kerül-e.

## **Hiperhivatkozások eltávolítása a bemutatókból**

Használd a [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) metódust a hiperhivatkozás konténerek (beleértve a szövegrész hivatkozásokat is) összegyűjtéséhez, mielőtt módosítanád őket. Az alábbi példa eltávolítja mindkét aktiválási típust az első diáról. Egy típus csak eltávolításához hívd meg kizárólag a [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metódust; a kattintásis akció eltávolítása nem távolítja el az egér‑felett akciót.

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

Feltétel nélküli eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) egy hívással eltávolítja mindkét aktiválási típust a kiválasztott környezetben. Szelektív takarításhoz és a master‑ok, elrendezések és jegyzetek lefedéséhez lásd a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás nyilvántartás felépítése**

Mielőtt egy bemutatót terjesztenél, készíts nyilvántartást a benne lévő interaktív műveletekről és webes hivatkozásokról. A [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy egyszerű URL‑lista. Vizsgáld meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) , mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) metódusokat minden konténeren. Ezek függetlenek: egy konténer mindkét műveletet is tartalmazhat, így egy teljes jelentés akár két sort is igényel konténerenként.

Csak alakzat‑szintű hiperhivatkozások beolvasása kihagyhatja a szövegrészekhez csatolt hivatkozásokat. Inkább a megfelelő környezetben kérdezd le, és őrizd meg a visszakapott konténereket, hogy később frissíthesd vagy eltávolíthasd azok műveleteit.

### **A bemutató, dia és szövegkeret környezetek lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) osztály a [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), a [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) és a [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) metódusokon keresztül érhető el. Minden környezet ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) visszaadja a kattintásos művelettel rendelkező konténereket.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) visszaadja az egér‑felett művelettel rendelkező konténereket.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) visszaadja az egy vagy mindkét művelettel rendelkező konténereket.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx` fájlt egy külső kattintásos hivatkozással, egy fájl egér‑felett hivatkozással, belső diánavigációval, egy szöveg egér‑felett hivatkozással és egy makró művelettel. Ezeket a műveleteket nem hajtja végre. Ugyanaz a három lekérdezés minden környezetben működik; a számok konténereket írnak le, nem a műveletek összegét. A szövegkeret környezet kizárja a körülvevő alakzat saját hivatkozásait.

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

Ezen példa esetén a bemutató- és dia‑lekérdezések mindegyike három kattintásos konténert, két egér‑felett konténert és három konténert jelent, amelyek valamelyik műveletet tartalmazzák. A szövegkeret lekérdezés egy konténert jelent minden kategóriában.

### **Műveletek és célpontok osztályozása**

Használd a [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) metódust egy művelet értelmezéséhez, mielőtt annak célpontját vizsgálnád. A [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is kiterjednek:

| Értékek | Jelentés auditáláskor |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; vizsgáld a URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés navigáció, a diavetítés kontextusában feloldva. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyéni bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik bemutató megnyitása; külön vizsgáld a webes URL‑ktől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) metódussal, a specifikus belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) metódussal olvasd. A belső műveletek és beépített parancsok esetleg nem rendelkeznek külső URL‑vel; egy üres URL nem jelenti, hogy a konténernek nincs művelete. Tartsd meg a [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) által visszaadott értéket, ha az eltér a normalizált URL‑től, és ha elérhető, a [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) által visszaadott buboréksúgót is tüntesd fel.

### **Jelentés, tisztítás és hiperhivatkozások ellenőrzése**

Az alábbi PHP példa beolvas egy meglévő bemutatót (használd a fent létrehozott fájlt), írása `hyperlink-audit.json`, egy szabályt alkalmaz, elmenti a `hyperlink-sanitized.pptx` fájlt, és újra megnyitja, hogy ismét ellenőrizze mindkét aktiválási típust. A módosítás előtt összegyűjti a konténereket, és referencia egyenlőséget használ, hogy ne dolgozza fel ugyanazt a konténert kétszer. A bemutató lekérdezései a szokásos diákat fedik le; egy csomagra kiterjedő nyilvántartás esetén kifejezetten lekérdezi a master‑okat, elrendezéseket, jegyzeteket, valamint a jegyzet‑ és kézijszóró master‑okat, ha elérhetők.

A jelentés rögzíti az egytől kezdődő diaindexet és a [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) értéket, ahol elérhető. Az [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) biztosítja a támogatott konténerekhez tartozó tulajdonos dia. A master‑ok, elrendezések és jegyzetek nem rendelkeznek hagyományos diainexxel és a környezetük alapján azonosíthatók. Az alakzat‑konténerek és a szövegrész‑formázási konténerek külön címkékkel rendelkeznek; a többi konténer típusa megtartja a futási időben kapott típusnevét. Minden konténer kap egy jelentés‑lokális azonosítót, hogy a két művelet összekapcsolható legyen. A jelentés a művelettípusokat a PHP enumeráció által definiált egész konstansokként tárolja.

Ez a szándékosan szigorú alkalmazáspolitika csak abszolút HTTPS URL‑eket és érvényes belső diacélpontokat engedélyez. Elutasítja a makrókat, programokat, fájl műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és más URL‑sémákat. Ezek az elutasítások politikai döntések, nem az Aspose.Slides biztonsági döntése. Az HTTPS önmagában nem garantálja a megbízhatóságot: adj hozzá host‑engedélylistákat és egyéb ellenőrzéseket az alkalmazásodhoz. Mind az eredeti, mind a normalizált külső URL‑eket ellenőrzi a rendszer. A példa a metaadatokat auditálja anélkül, hogy a hivatkozásokat követné vagy műveleteket futtatna.

A javításhoz a konténer [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), a [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) metódusokat. Itt a tiltott külső kattintásos hivatkozásokat egy rögzített HTTPS céloldallal helyettesítik; a többi tiltott kattintás és tiltott egér‑felett művelet önállóan eltávolításra kerül. Állítsd `$replaceExternalClicks` értékét `false`-ra, ha az összes szabálysértést el akarod távolítani. Válassz egy alkalmazáson belüli helyettesítő oldalt a telepítés előtt.

A jelentés exportálási jelzője egy konzervatív PDF ellenőrzési politikát alkalmaz: az egér‑felett műveleteket és minden egyéb, nem külső hivatkozás vagy konkrét diaugrás, potenciálisan nem támogatottként jelöli. Ez egy felülvizsgálati jelzés, nem pedig képességteszt vagy garancia arra, hogy a jelölés nélküli hivatkozások megmaradnak az exportálás során. A támogatott [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/php-java/convert-powerpoint-to-html/) exportok megtarthatják a hiperhivatkozásokat, az akciótól, az export beállításaitól és a megjelenítőtől függően. A raszteres [képek](/slides/hu/php-java/convert-powerpoint-to-png/) és [videó](/slides/hu/php-java/convert-powerpoint-to-video/) nem képesek az interaktív hiperhivatkozásokat megtartani; ezért auditáláskor minden akciót jelölj meg ezeknek a kimeneteknek.

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

A fenti bemenet alapján a jelentés öt műveleti sort tartalmaz. A fájl egér‑felett hivatkozás és a makró kattintás eltávolításra kerül, míg a HTTPS hivatkozások és a belső dianézet megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintás URL-t tartalmazó bemenet a helyettesítési ágat is végrehajtja. Egy konténer, amelynek engedélyezett kattintása és tiltott egér‑felett művelete van, megtartja a kattintási műveletet.

Ez a szelektív tisztítás eltér a [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) módszertől, amely a kiválasztott környezetben a szabálytól függetlenül mindkét aktiválási típust eltávolítja. Itt az ellenőrzés csak a hiperhivatkozás műveleteket vizsgálja; nem távolítja el a beágyazott VBA projekteket, OLE objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi az exportált PDF vagy HTML fájlokat.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPoint szekciók diák csoportját alkotják, de egy belső hiperhivatkozás egyetlen diát céloz meg. Egy szekcióra való navigáció létrehozásához linkelj a szekció első diájára.

**Csatolhatok-e hiperhivatkozást a mesterdia elemeihez, hogy minden diabón működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő hivatkozások a diavetítés során elérhetők azon diákon, amelyek a megfelelő master‑t vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok esetleg megőrzik a hiperhivatkozásokat; a raszteres képek és videók nem. Tekintsd meg az exportálási szempontokat a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részben.