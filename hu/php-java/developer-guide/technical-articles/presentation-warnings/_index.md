---
title: Bemutató figyelmeztetések kezelése PHP-ben
type: docs
weight: 90
url: /hu/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztető visszahívás
- figyelmeztetési szabály
- adatvesztés
- forráskorruptió
- kompatibilitási probléma
- betűtípus helyettesítés
- digitális aláírás
- bemutató betöltése
- bemutató renderelése
- bemutató konvertálása
- bemutató mentése
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan gyűjtheti össze, osztályozhatja és kezelheti a figyelmeztetéseket a bemutatók betöltése, renderelése, konvertálása és mentése során az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Aspose.Slides képes jelenteni a helyreállítható problémákat, amikor betölti, rendereli, konvertálja vagy menti a bemutatót. Példák közé tartozik a sérült forrásrekordok, a nem megőrizhető tartalom, a betűtípus helyettesítés és a célformátum korlátai. Egy figyelmeztető visszahívás lehetővé teszi az alkalmazás számára, hogy rögzítse ezeket a körülményeket, és eldöntse, hogy a jelenlegi művelet folytatható-e.

Hozzon létre egy PHP osztályt nyilvános `warning` metódussal, és tegye elérhetővé a PHP Java Bridge-en keresztül Java [IWarningCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarningcallback/) interfészként a `java_closure` használatával. Tekintse meg a [getWarningType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getWarningType--) és [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) értékeket, amelyeket az [IWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/) szolgáltat. Adja vissza a [ReturnAction::Continue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/returnaction/#Continue) értéket a figyelmeztetés elfogadásához, vagy a [ReturnAction::Abort](https://reference.aspose.com/slides/hu/php-java/aspose.slides/returnaction/#Abort) értéket a művelet leállításához.

Használja a [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setWarningCallback) funkciót a bemutató megnyitásakor keletkező figyelmeztetésekhez. A renderelés és export beállítási osztályok öröklik a [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setWarningCallback) metódust, amely a diák renderelésekor, konvertálásakor és mentésekor érkező figyelmeztetéseket kapja. Mivel maga a figyelmeztetés nem azonosítja az alkalmazás műveletét, társítsa minden visszahíváspéldányt egy műveleti fázishoz, amikor kombinált jelentést épít.

## **Figyelmeztetések és kivételek**

A Java kivételek a PHP Java Bridge-en keresztül elérhetők PHP‑ban; fogja el őket a művelet határán, ahogyan az alábbi példában látható. A cikkben szereplő Java interfész‑linkek leírják a híd által használt visszahívási szerződést.

Egy figyelmeztetés olyan körülményt ír le, amelyből az Aspose.Slides helyreállhat, ha a visszahívás `ReturnAction::Continue`‑t ad vissza. Egy kivétel azt jelenti, hogy a kért művelet nem fejezhető be normál módon; a kivételek nem alakulnak figyelmeztetéssé, ezért egy figyelmeztetési szabály nem kezelheti őket.

A `ReturnAction::Abort` visszaadása azt kéri a figyelmeztetéskezelőt, hogy egy kivételt dobva szakítsa le a jelenlegi műveletet. A nyilvános kivétel a művelettől és a bemutató formátumától függ. Például a betöltés során felmerülhet egy [PptxReadException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxreadexception/) vagy [PptReadException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptreadexception/), míg a mentés vagy export során egy [PptxException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxexception/). Kezelje a kivételt a művelet határán, és a figyelmeztetési jelentés alapján döntse el, hogy az alkalmazás szabálya okozta‑e a leállást, ahelyett, hogy egyetlen kivétel alosztályra vagy üzenetre támaszkodna. A visszahívás a figyelmeztetést a `ReturnAction::Abort` visszaadása előtt rögzíti, ezzel biztosítva, hogy az ok továbbra is elérhető legyen az alkalmazás számára.

## **Figyelmeztetési kategóriák**

A [WarningType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/warningtype/) osztály egész számú konstansokat biztosít a következő kategóriákhoz:

| Figyelmeztetés típusa | Jelentés | Tipikus szabály |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/warningtype/#SourceFileCorruption) | A forrásbemutató hibákat tartalmaz, amelyek miatt az eredeti formátumban mentett dokumentum használhatatlanná válhat. | Megszakítás. |
| [DataLoss](https://reference.aspose.com/slides/hu/php-java/aspose.slides/warningtype/#DataLoss) | Szöveg, diagram, kép vagy egyéb adat hiányozhat a betöltés vagy mentés után. | Megszakítás. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hu/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | A bemutató fontos formázásának elvesztése lehetséges. | Megszakítás szigorú ellenőrző módban; egyébként rögzítés és folytatás. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hu/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Korlátozott formázási eltérés fordulhat elő. | Diagnosztikai célú rögzítés és folytatás. |
| [CompatibilityIssue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Az eredmény egyes alkalmazásokban vagy régebbi verziókban nem nyílik meg vagy nem viselkedik helyesen. | Naplózás és folytatás, kivéve ha a kompatibilitás kötelező. |
| [UnexpectedContent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/warningtype/#UnexpectedContent) | A forrás nem támogatott vagy ismeretlen tartalmat tartalmaz, amelynek hatása még ismeretlen. | Rögzítés és folytatás, vagy szigorú szabály esetén hiba. |

A kategória határozza meg a szabályi döntést. A diagnosztikához tárolja a [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értéket, de ne a szövegét használja alkalmazáslogikához, mivel a üzenet szövege változhat a figyelmeztetési forgatókönyvek és a termékváltozatok között.

## **Figyelmeztetések összegyűjtése és osztályozása**

Az alábbi példa egy alkalmazásszintű jelentést használ a teljes feldolgozási csővezetékhez. Egy külön visszahívás‑példány címkézi a betöltés, renderelés, PDF‑konvertálás és PPTX‑mentés során keletkező figyelmeztetéseket. A szabály forráskorruptió vagy adatvesztés esetén megszakít, opcionálisan megszakít nagy formázási veszteség esetén, a többi figyelmeztetésnél folytat. A visszahívás a figyelmeztetési értékeket a `java_values`‑szal natív PHP‑értékekké alakítja a rögzítés és összehasonlítás előtt.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

A `WarningPolicy` létrehozásakor adjon `false` értéket az `abortOnMajorFormattingLoss` paraméternek, ha a nagy formázási eltérések elfogadhatóak. A kompatibilitási problémák, kisebb formázási veszteség és a váratlan tartalom továbbra is szerepel a jelentésben, még ha a művelet folytatódik is. Bővítse a `WarningPolicy::getAction`‑t, ha az alkalmazásnak el kell utasítania bármelyik ezen kategória közül.

## **Gyakori figyelmeztetési szcenáriók**

A figyelmeztetések a munkafolyamat különböző szakaszaiban jelentkezhetnek:

- **Digitális aláírások:** Egy aláírt bemutató betöltéskor figyelmeztetést adhat, hogy az aláírás elveszik a feldolgozás során. Az Aspose.Slides ezt a `DataLoss` állapotot az [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationsignedwarninginfo/) segítségével jelenti. A betöltési szakasz visszahívása lehetővé teszi, hogy az alkalmazás elutasítsa a fájlt vagy kifejezetten elfogadja a jelentett veszteséget.
- **Betűtípus helyettesítés:** Egy nem elérhető betűtípust helyettesíthetnek, amikor egy dia renderelődik vagy exportálódik. A betűtípus‑helyettesítési figyelmeztetéseket `DataLoss`‑ként jelentik, így a fenti szigorú szabály megszakít, még ha az alkalmazás egy adott helyettesítést vizuálisan elfogadhatónak is tekint. Ennek megfigyeléséhez használjon egy bemeneti bemutatót, amely olyan betűtípust tartalmaz, amely nem érhető el a futtatókörnyezetben. A figyelmeztetés leírása azonosítja a helyettesítést; állítsa be a szükséges betűtípusokat vagy a [betűtípus‑helyettesítési szabályokat](/slides/hu/php-java/font-substitution/) a újbóli próbálkozás előtt.
- **Nem támogatott vagy váratlan tartalom:** A betöltő olyan bemutatórekordokkal vagy funkciókkal találkozhat, amelyeket nem ismer fel. Ilyen figyelmeztetések a `UnexpectedContent`‑t, vagy súlyosabb kategóriát használhatnak, ha adatok vagy formázás érintett.
- **Formátum kompatibilitás:** Egy másik bemutatóformátumba mentés kihagyhat funkciókat vagy olyan eredményt hozhat, amely egyes alkalmazásokban másként viselkedik. Például egy nyolc vízszintes vagy nyolc függőleges rajzvezetővel ellátott bemutató mentése a régi PPT‑formátumba `CompatibilityIssue`‑t jelent. A mentés‑szakasz visszahívása rögzítheti a veszteséget és folytathatja, vagy elutasíthatja, ha az összes vezető megőrzése kötelező.
- **Betöltési viselkedés:** A betöltési beállítások és örökölt viselkedések is generálhatnak figyelmeztetéseket. Például az [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) egy elavult prezentáció‑zárolási viselkedés használatát `CompatibilityIssue`‑ként azonosítja.

A figyelmeztetések a forrásdokumentumtól, a célformátumtól, a művelettől és az Aspose.Slides verziójától függenek. Ne feltételezze, hogy minden fájl figyelmeztetést generál, vagy hogy egy szcenárió mindig csak egy kategóriába sorolható.

## **Biztonságos leállított műveletek kezelése**

Ha egy visszahívás `ReturnAction::Abort`‑ot ad vissza, ne használjon egy olyan objektumot, amely nem töltött be, és ne feltételezze, hogy a renderelés vagy mentés kimenete teljes. A művelet befejeződhet egy kimeneti fájl létrehozása után, de még mielőtt az teljesen elkészülne.

Mentse a validált eredményt egy külön útvonalra, például `validated-output.pptx`. Egy meglévő bemutatót csak akkor írjon felül, ha a művelet sikeresen befejeződött, a figyelmeztetési jelentés megfelel az alkalmazás szabályainak, és a kimenet megnyitható és ellenőrizhető. Ez megakadályozza, hogy egy részleges vagy elutasított eredménnyel felülírja a valid forrásfájlt.

Az üres figyelmeztetési jelentés nem garancia arra, hogy minden forrásjellemző megmaradt. Alkalmazzon minden további tartalom‑ és vizuális ellenőrzést, amelyet az alkalmazás megkövetel. Lásd még a [Prezentációk megnyitása](/slides/hu/php-java/open-presentation/) és a [Prezentációk mentése](/slides/hu/php-java/save-presentation/) oldalakat.

## **GYIK**

**Kezelhet-e egy figyelmeztető visszahívás minden Aspose.Slides hibát?**

Nem. Csak a figyelmeztetésként jelentett helyreállítható körülményeket kezeli. A visszahívástól függetlenül előforduló kivételeket az alkalmazásnak kell kezelnie a betöltés, renderelés, konvertálás vagy mentés hívása körül.

**Garantálja a `ReturnAction::Continue` visszaadása azonos kimenetet?**

Nem. Csak azt engedélyezi, hogy a feldolgozás folytatódjon. A jelentett körülmény továbbra is adat-, formázás‑ vagy kompatibilitás‑eltéréseket eredményezhet, ezért át kell tekinteni a gyűjtött figyelmeztetéstípusokat és leírásokat.

**Hogyan tud egy alkalmazás azonosítani azt a műveletet, amely a figyelmeztetést generálta?**

Hozzon létre egy visszahívás‑példányt minden művelethez, és tárolja egy alkalmazás‑definiált szakaszt a [getWarningType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getWarningType--) és [getDescription](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iwarninginfo/#getDescription--) által visszaadott értékekkel, ahogy a példában látható.