---
title: Prezentáció figyelmeztetések kezelése Pythonban Java‑on keresztül
type: docs
weight: 90
url: /hu/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- figyelmeztetési visszahívás
- figyelmeztetési szabályzat
- adatveszteség
- forrás‑sérülés
- kompatibilitási probléma
- betűkészlet‑helyettesítés
- digitális aláírás
- prezentáció betöltés
- prezentáció renderelés
- prezentáció konvertálás
- prezentáció mentés
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan gyűjtheti, osztályozhatja és kezelheti a figyelmeztetéseket a prezentációk betöltése, renderelése, konvertálása és mentése során az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides jelenthet helyrehozható problémákat a betöltés, renderelés, konvertálás vagy a prezentáció mentése során. Példák: sérült forrásrekordok, megőrizhetetlen tartalom, betűkészlet‑helyettesítés és a célformátum korlátai. Egy figyelmeztető visszahívás lehetővé teszi, hogy az alkalmazás rögzítse ezeket a feltételeket, és eldöntse, folytatható‑e a jelenlegi művelet.

Valósítsa meg az `IWarningCallback` felületet a `jpype.JProxy` segítségével, és vizsgálja meg az `IWarningInfo` által biztosított `getWarningType` és `getDescription` értékeket. A [ReturnAction.Continue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/returnaction/#Continue) visszatérésével elfogadhatja a figyelmeztetést, vagy a [ReturnAction.Abort](https://reference.aspose.com/slides/hu/python-java/aspose.slides/returnaction/#Abort) visszatérésével leállíthatja a műveletet.

Használja a [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setWarningCallback) hívást a prezentáció megnyitása során felmerülő figyelmeztetésekhez. A renderelés és export opció osztályok öröklik a [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setWarningCallback) metódust, amely a diák renderelése, konvertálása és mentése során kapott figyelmeztetéseket fogadja. Mivel a figyelmeztetés önmagában nem azonosítja az alkalmazás műveletét, a kombinált jelentés összeállításakor társítsa az egyes visszahívási példányokat egy műveleti állapottal.

## **Figyelmeztetések és kivételek**

A figyelmeztetés egy olyan feltételt ír le, amelyből az Aspose.Slides helyre tud térni, ha a visszahívás `ReturnAction.Continue`‑t ad vissza. A kivétel azt jelenti, hogy a kért művelet nem fejezhető be normál módon; a kivételek nem alakulnak át figyelmeztetésekké, és figyelmeztetési szabályzattal nem kezelhetők.

A `ReturnAction.Abort` visszatérése a figyelmeztetési diszpécsert arra kéri, hogy a jelenlegi műveletet kivétel dobásával állítsa le. A publikus kivétel a művelettől és a prezentáció formátumától függ. Például a betöltés során előfordulhat egy [PptxReadException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxreadexception/) vagy [PptReadException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptreadexception/), míg a mentés vagy export esetén egy [PptxException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxexception/). Kezelje a kivételt a művelet határán, és használja a figyelmeztetési jelentést annak meghatározására, hogy az alkalmazás szabályzata okozta-e a leállást, ahelyett, hogy egyetlen kivétel alosztályra vagy üzenetre támaszkodna. A visszahívás a figyelmeztetést a `ReturnAction.Abort` visszatérése előtt rögzíti, biztosítva, hogy az ok a későbbiekben is elérhető legyen az alkalmazás számára.

## **Figyelmeztetés kategóriák**

A [WarningType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/warningtype/) osztály egész számú konstansokat biztosít a következő kategóriákhoz:

| Figyelmeztetés típusa | Jelentés | Tipikus szabályzat |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/hu/python-java/aspose.slides/warningtype/#SourceFileCorruption) | A forrásprezentáció sérülést tartalmaz, ami azt eredményezheti, hogy az eredeti formátumban mentett dokumentum használhatatlanná válik. | Megszakítás. |
| [DataLoss](https://reference.aspose.com/slides/hu/python-java/aspose.slides/warningtype/#DataLoss) | Szöveg, diagramok, képek vagy egyéb adatok hiányozhatnak a betöltés vagy mentés után. | Megszakítás. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/hu/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | A prezentáció elveszítheti a fontos formázást. | Megszakítás szigorú validációs módban; egyébként rögzítés és folytatás. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/hu/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Korlátozott formázási eltérés fordulhat elő. | Rögzítés diagnosztika céljából és folytatás. |
| [CompatibilityIssue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Az eredmény egyes alkalmazásokban vagy régebbi verziókban esetleg nem nyílik meg, vagy nem működik megfelelően. | Naplózás és folytatás, hacsak a kompatibilitás kötelező. |
| [UnexpectedContent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/warningtype/#UnexpectedContent) | A forrás nem támogatott vagy ismeretlen tartalmat tartalmaz, amelynek hatása még nem ismert. | Rögzítés és folytatás, vagy szigorú szabályzat esetén hibaként kezelés. |

A kategória kell, hogy irányítsa a szabályzati döntést. Tárolja a `getDescription` által visszaadott értéket diagnosztikai célokra, de ne támaszkodjon a szövegre üzleti logikában, mivel a szöveg a figyelmeztetés szcenáriójától és a termék verziójától függően változhat.

## **Figyelmeztetések gyűjtése és osztályozása**

Az alábbi példa egy alkalmazásszintű jelentést használ a teljes feldolgozási csővezetékhez. Egy külön visszahívási példány címkézi a betöltés, renderelés, PDF‑konvertálás és PPTX‑mentés során keletkezett figyelmeztetéseket. A szabályzat megszakítja a műveletet forrás‑sérülés vagy adatveszteség esetén, opcionálisan megszakítja a nagy formázási veszteség esetén, és a többi figyelmeztetést folytatja.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Adjon meg `False` értéket a `abort_on_major_formatting_loss` paraméterhez a `WarningPolicy` létrehozásakor, ha a nagy formázási eltérések elfogadhatóak. A kompatibilitási problémák, a kisebb formázási veszteség és a váratlan tartalom továbbra is szerepelnek a jelentésben, még akkor is, ha a művelet folytatódik. Bővítse a `WarningPolicy.get_action` metódust, ha az alkalmazásnak el kell utasítania bármelyik ilyen kategóriát.

## **Gyakori figyelmeztetési helyzetek**

A figyelmeztetések különböző munkafolyamat‑szakaszokban jelentkezhetnek:

- **Digitális aláírások:** Egy aláírt prezentáció betöltésekor figyelmeztetés jelenhet meg arról, hogy az aláírás elveszik a feldolgozás során. Az Aspose.Slides ezt a `DataLoss` feltételt az `IPresentationSignedWarningInfo`‑on keresztül jelzi. A betöltési szakasz visszahívása lehetővé teszi az alkalmazás számára, hogy elutasítsa a fájlt vagy kifejezetten elfogadja a jelentett adatvesztést.
- **Betűkészlet‑helyettesítés:** Egy nem elérhető betűkészlet helyettesíthető a dia renderelése vagy exportálása közben. A betűkészlet‑helyettesítési figyelmeztetéseket `DataLoss`‑ként jelenti, ezért a fent bemutatott szigorú szabályzat még akkor is megszakítja a folyamatot, ha az alkalmazás a helyettesítést vizuálisan elfogadhatónak tartaná. Ennek megfigyeléséhez használjon olyan bemeneti prezentációt, amely nem elérhető betűkészletet tartalmaz. A figyelmeztetés leírása feltárja a helyettesítést; konfigurálja a szükséges betűkészleteket vagy [betűkészlet‑helyettesítési szabályokat](/slides/hu/python-java/font-substitution/) a újrapróbálkozás előtt.
- **Nem támogatott vagy váratlan tartalom:** A betöltő találkozhat olyan prezentációs rekordokkal vagy funkciókkal, amelyeket nem ismer fel. Az ilyen figyelmeztetések használhatják az `UnexpectedContent`‑ot, vagy súlyosabb kategóriát, ha az adatok vagy a formázás is érintett.
- **Formátum‑kompatibilitás:** Másik prezentációformátumba mentés esetén bizonyos funkciók kimaradnak, vagy az eredmény másképp viselkedhet egyes alkalmazásokban. Például egy prezentáció mentése, amely nyolcnál több vízszintes vagy függőleges rajzolási segédvonalat tartalmaz, a régi PPT‑formátumban `CompatibilityIssue`‑t jelent. A mentési szakasz visszahívása rögzítheti a veszteséget és folytathatja, vagy elutasíthatja, ha minden segédvonal megőrzése kötelező.
- **Betöltési viselkedés:** A betöltési opciók és a régi viselkedések is generálhatnak figyelmeztetéseket. Például az `IObsoletePresLockingBehaviorWarningInfo` egy elavult prezentáció‑zárolási viselkedést azonosít `CompatibilityIssue`‑ként.

A figyelmeztetések a forrásdokumentumtól, a célformátumtól, a művelettől és az Aspose.Slides verziójától függnek. Ne feltételezze, hogy minden fájl figyelmeztetést generál, vagy hogy egy szituáció csak egy kategóriába sorolható.

## **Megszakított műveletek biztonságos kezelése**

Ha egy visszahívás `ReturnAction.Abort`‑ot ad vissza, ne használjon olyan objektumot, amely betöltése sikertelen volt, és ne tételezze fel, hogy egy renderelési vagy mentési kimenet teljes. A művelet megállhat egy kimeneti fájl létrehozása után, de még mielőtt az befejeződne.

Mentse a validált eredményeket egy külön útvonalra, például `validated-output.pptx`. Egy már létező prezentációt csak akkor cseréljen le, ha a művelet sikeresen befejeződött, a figyelmeztetési jelentés megfelel az alkalmazás szabályzatának, és a kimenet megnyitható és ellenőrizhető. Ezzel elkerülhető, hogy egy részleges vagy elutasított eredmény felülírja a valid forrásfájlt.

Az üres figyelmeztetési jelentés nem garantálja, hogy minden forrásfunkció megmaradt. Alkalmazzon minden további tartalom‑ és vizuális ellenőrzést, amelyet az alkalmazás megkövetel. Lásd még a [Open Presentations](/slides/hu/python-java/open-presentation/) és a [Save Presentations](/slides/hu/python-java/save-presentation/) oldalakat.

## **GYIK**

**Kezelhet-e egy figyelmeztető visszahívás minden Aspose.Slides hibát?**

Nem. Csak a figyelmeztetésként jelentett helyrehozható feltételeket kezeli. Azoktól a kivételektől, amelyek a visszahívástól függetlenül fordulnak elő, az alkalmazásnak kell gondoskodnia a betöltés, renderelés, konvertálás vagy mentés hívás körül.

**Garantálja a `ReturnAction.Continue` visszatérés azonos kimenetet?**

Nem. Csak azt engedélyezi, hogy a feldolgozás folytatódjon. A jelentett feltétel továbbra is okozhat adat-, formázási vagy kompatibilitási különbségeket, ezért a gyűjtött figyelmeztetéstípusokat és leírásokat érdemes átnézni.

**Hogyan azonosíthatja az alkalmazás, melyik művelet okozta a figyelmeztetést?**

Hozzon létre egy visszahívási példányt minden egyes művelethez, és tárolja az alkalmazás által definiált állapotot együtt a `getWarningType` és `getDescription` által visszaadott értékekkel, ahogyan a példában látható.