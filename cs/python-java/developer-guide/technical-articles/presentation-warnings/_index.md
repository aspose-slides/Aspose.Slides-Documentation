---
title: Zpracování výstrah prezentace v Pythonu pomocí Java
type: docs
weight: 90
url: /cs/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- výstražná zpětná volání
- politika výstrah
- ztráta dat
- poškození zdroje
- problém kompatibility
- náhrada písma
- digitální podpis
- načítání prezentace
- vykreslování prezentace
- konverze prezentace
- ukládání prezentace
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Naučte se shromažďovat, klasifikovat a reagovat na výstrahy při načítání, vykreslování, konverzi a ukládání prezentací pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides může hlásit obnovitelné problémy během načítání, vykreslování, převodu nebo ukládání prezentace. Příklady zahrnují poškozené zdrojové záznamy, obsah, který nelze zachovat, náhradu písma a omezení cílového formátu. Výstražná zpětná volání umožňuje aplikaci zaznamenat tyto podmínky a rozhodnout, zda může současná operace pokračovat.

Implementujte rozhraní `IWarningCallback` prostřednictvím `jpype.JProxy` a prozkoumejte hodnoty `getWarningType` a `getDescription` dodávané přes `IWarningInfo`. Vraťte [ReturnAction.Continue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/returnaction/#Continue) pro přijetí výstrahy nebo [ReturnAction.Abort](https://reference.aspose.com/slides/cs/python-java/aspose.slides/returnaction/#Abort) pro zastavení operace.

Použijte [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setWarningCallback) pro výstrahy vyvolané při otevírání prezentace. Třídy pro vykreslování a exportní možnosti dědí [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveoptions/#setWarningCallback), která přijímá výstrahy z vykreslování snímků, převodu a ukládání. Protože samotná výstraha neidentifikuje operaci aplikace, při vytváření kombinované zprávy spojte každou instanci zpětné volání s fází operace.

## **Výstrahy a výjimky**

Výstraha popisuje podmínku, ze které se Aspose.Slides může zotavit, pokud zpětná volání vrátí `ReturnAction.Continue`. Výjimka znamená, že požadovaná operace nemůže být dokončena normálně; výjimky nejsou převáděny na výstrahy a nemohou být zpracovány výstražnou politikou.

Vrácení `ReturnAction.Abort` požaduje od výstražného dispečera ukončení aktuální operace vyvoláním výjimky. Veřejná výjimka závisí na operaci a formátu prezentace. Například načítání může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxreadexception/) nebo [PptReadException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptreadexception/), zatímco ukládání nebo export může vyvolat [PptxException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxexception/). Ošetřete výjimku na hranici operace a použijte výstražnou zprávu k určení, zda politika aplikace způsobila ukončení místo spolehnutí se na jeden podtyp výjimky nebo zprávu. Zpětná volání zaznamená výstrahu před vrácením `ReturnAction.Abort`, čímž zajistí, že důvod zůstane dostupný aplikaci.

## **Kategorie výstrah**

Třída [WarningType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/warningtype/) poskytuje celočíselné konstanty pro následující kategorie:

| Typ výstrahy | Význam | Typická politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/cs/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Zdrojová prezentace obsahuje poškození, které může způsobit, že dokument uložený v původním formátu bude nevyužitelný. | Ukončit. |
| [DataLoss](https://reference.aspose.com/slides/cs/python-java/aspose.slides/warningtype/#DataLoss) | Po načtení nebo uložení může chybět text, grafy, obrázky nebo jiná data. | Ukončit. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/cs/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Prezentace může ztratit důležité formátování. | Ukončit v režimu přísné validace; jinak zaznamenat a pokračovat. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/cs/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Může dojít k omezenému rozdílu ve formátování. | Zaznamenat pro diagnostiku a pokračovat. |
| [CompatibilityIssue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Výsledek se nemusí otevřít nebo správně fungovat v některých aplikacích či starších verzích. | Zaznamenat a pokračovat, pokud není kompatibilita povinná. |
| [UnexpectedContent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/warningtype/#UnexpectedContent) | Zdroj obsahuje nepodporovaný nebo nerozpoznaný obsah, jehož dopad ještě není znám. | Zaznamenat a pokračovat, nebo v přísné politice považovat za chybu. |

Kategorie by měla určovat rozhodnutí politiky. Uložte hodnotu vrácenou `getDescription` pro diagnostiku, ale nespoléhejte se na její znění při logice aplikace, protože text zprávy se může lišit mezi scénáři výstrah a verzemi produktu.

## **Sbírat a klasifikovat výstrahy**

Následující příklad používá jednu úroveň zprávy aplikace pro celý zpracovatelský řetězec. Samostatná instance zpětné volání označuje výstrahy z načítání, vykreslování, konverze do PDF a ukládání PPTX. Politika ukončuje při poškození zdroje nebo ztrátě dat, volitelně ukončuje při velké ztrátě formátování a pokračuje u ostatních výstrah.

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

Při vytváření `WarningPolicy` předávejte `False` pro `abort_on_major_formatting_loss`, pokud jsou hlavní rozdíly ve formátování přijatelné. Problémy s kompatibilitou, menší ztráta formátování a neočekávaný obsah jsou i tak zachovány ve zprávě, i když operace pokračuje. Rozšiřte `WarningPolicy.get_action`, pokud aplikace musí odmítnout některou z těchto kategorií.

## **Běžné scénáře výstrah**

Výstrahy se mohou objevit v různých fázích pracovního postupu:

- **Digitální podpisy:** Podepsaná prezentace může při načítání vyvolat výstrahu, že její podpis bude během zpracování ztracen. Aspose.Slides tuto podmínku `DataLoss` hlásí prostřednictvím `IPresentationSignedWarningInfo`. Zpětná volání v načítací fázi umožňuje aplikaci soubor odmítnout nebo výslovně přijmout hlášenou ztrátu.
- **Náhrada písma:** Nedostupné písmo může být nahrazeno během vykreslování nebo exportu snímku. Výstrahy z náhrady písma jsou hlášeny jako `DataLoss`, takže přísná politika výše ukončí i když by aplikace považovala konkrétní náhradu za vizuálně přijatelnou. Pro pozorování tohoto chování použijte vstupní prezentaci obsahující text v písmu nedostupném v době běhu. Popis výstrahy identifikuje náhradu; nakonfigurujte požadovaná písma nebo [pravidla náhrady písma](/slides/cs/python-java/font-substitution/) před dalším pokusem.
- **Nepodporovaný nebo neočekávaný obsah:** Načítací komponenta může narazit na záznamy nebo funkce prezentace, které nepozná. Takové výstrahy mohou použít `UnexpectedContent` nebo závažnější kategorii, pokud jsou data nebo formátování známy jako postižené.
- **Kompatibilita formátu:** Ukládání do jiného formátu prezentace může vynechat funkce nebo vytvořit výsledek, který se v některých aplikacích chová odlišně. Například uložení prezentace s více než osmi vodorovnými nebo svislými kreslicími vodítky do staršího PPT hlásí `CompatibilityIssue`. Zpětná volání v ukládací fázi může ztrátu zaznamenat a pokračovat, nebo ji odmítnout, pokud je zachování všech vodítek vyžadováno.
- **Chování při načítání:** Možnosti načítání a staré chování mohou také generovat výstrahy. Například `IObsoletePresLockingBehaviorWarningInfo` identifikuje použití zastaralého chování zamykání prezentace jako `CompatibilityIssue`.

Výstrahy závisí na zdrojovém dokumentu, cílovém formátu, operaci a verzi Aspose.Slides. Nepředpokládejte, že každý soubor vygeneruje výstrahu nebo že scénář vždy spadá jen do jedné kategorie.

## **Bezpečné zacházení s přerušenými operacemi**

Když zpětná volání vrátí `ReturnAction.Abort`, nepoužívejte objekt, který se nepodařilo načíst, a nepředpokládejte, že výstup vykreslení nebo uložení je kompletní. Operace může skončit po vytvoření výstupního souboru, ale před jeho dokončením.

Ukládejte ověřené výsledky do samostatné cesty, například `validated-output.pptx`. Stávající prezentaci nahraďte až po úspěšném dokončení operace, pokud zpráva o výstrahách splňuje politiku aplikace a výstup lze otevřít a zkontrolovat. Tím se zabrání přepsání platného zdrojového souboru částečným nebo odmítnutým výsledkem.

Prázdná zpráva o výstrahách není zárukou, že každý zdrojový prvek byl zachován. Proveďte případné další kontroly obsahu a vizuální kontroly požadované aplikací. Viz také [Open Presentations](/slides/cs/python-java/open-presentation/) a [Save Presentations](/slides/cs/python-java/save-presentation/).

## **Často kladené otázky**

**Může výstražná zpětná volání zvládnout každou chybu Aspose.Slides?**

Ne. Zvládá pouze obnovitelné podmínky hlášené jako výstrahy. Výjimky, které nastanou nezávisle na zpětné volání, musí být ošetřeny aplikací kolem volání načítání, vykreslování, převodu nebo ukládání.

**Zaručuje vrácení `ReturnAction.Continue` stejný výstup?**

Ne. Pouze umožní pokračovat ve zpracování. Nahlášená podmínka může stále způsobit rozdíly v datech, formátování nebo kompatibilitě, proto přezkoumejte shromážděné typy výstrah a jejich popisy.

**Jak může aplikace identifikovat operaci, která výstrahu vyvolala?**

Vytvořte samostatnou instanci zpětné volání pro každou operaci a uložte aplikací definovanou fázi spolu s hodnotami vrácenými `getWarningType` a `getDescription`, jak ukazuje příklad.