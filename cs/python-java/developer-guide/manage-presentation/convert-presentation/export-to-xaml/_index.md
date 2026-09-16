---
title: Exportovat prezentace do XAML v Pythonu přes Java
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/python-java/export-to-xaml/
keywords:
- exportovat PowerPoint
- exportovat OpenDocument
- exportovat prezentaci
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- PowerPoint do XAML
- OpenDocument do XAML
- prezentace do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- uložit PPT jako XAML
- uložit PPTX jako XAML
- uložit ODP jako XAML
- exportovat PPT do XAML
- exportovat PPTX do XAML
- exportovat ODP do XAML
- Python
- Java
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do XAML pomocí Aspose.Slides pro Python přes Java. Použijte výchozí možnosti nebo zahrňte skryté snímky."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides pro Python via Java. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik často kladených otázek týkajících se náhradních fontů, kompatibility XAML stacku a chování exportu skrytých snímků.

Příklady vyžadují Aspose.Slides pro Python via Java a kompatibilní Java runtime. Umístěte `pres.pptx` do aktuálního pracovního adresáře. Každý příklad spustí JVM pouze pokud ještě neběží.

## **O XAML**

XAML je jazyk značkování založený na XML, který se používá k popisu uživatelských rozhraní v rámcích jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

Můžete pracovat se soubory XAML ve vizuálním návrháři nebo psát a upravovat značkování přímo.

## **Export prezentací do XAML s výchozími možnostmi**

Příští příklad v Pythonu ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Standardně jsou exportované snímky uloženy v podsložce `pres` aktuálního pracovního adresáře procesu. Složka je vytvořena automaticky a všechny potřebné obrázky jsou uloženy také tam.

Název výstupní složky je odvozen od názvu zdrojového souboru bez přípony. Pro `pres.pptx` jsou výstupní soubory pojmenovány `pres/Slide_1.xaml`, `pres/Slide_2.xaml` a tak dále. I když zadáte absolutní cestu k vstupní prezentaci, výstupní složka je vytvořena relativně k aktuálnímu pracovnímu adresáři, nikoli vedle vstupního souboru.

## **Export prezentací do XAML s vlastními možnostmi**

Použijte třídu [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/) k řízení toho, jak Aspose.Slides exportuje prezentaci do XAML.

Aby bylo výstupní umístění vlastní, implementujte `IXamlOutputSaver` a předajte instanci vaší implementace metodě [setOutputSaver](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/#setOutputSaver) třídy [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/).

Pro zahrnutí skrytých snímků do výstupu XAML zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) s hodnotou `True`, jak je ukázáno v následujícím příkladu v Pythonu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Zachycení všech vygenerovaných XAML artefaktů**

Export XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Přiřaďte vlastní `IXamlOutputSaver` k [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/#setOutputSaver) abyste tyto artefakty získali místo výchozího ukládání do souborového systému. Spusťte export pomocí XAML‑specific [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) přetížení, které přijímá XAML možnosti.

V Pythonu použijte `jpype.JProxy` k implementaci Java rozhraní `IXamlOutputSaver`. Převeďte cestu zpětného volání na `str` a zkopírujte Java bytové pole do Python `bytes` před návratem, jak je ukázáno níže.

### **Porozumění životnímu cyklu zpětného volání**

- `path` identifikuje artefakt a může obsahovat relativní adresáře. Uchovejte tuto informaci, protože XAML může odkazovat na zdroje pomocí relativních cest.
- `data` obsahuje bajty artefaktu. Obrázky a jiné binární zdroje nesmí být dekódovány jako text.
- Ukládání je zodpovědné za uchování nebo trvalé uložení dat před návratem. Příklady kopírují každé bytové pole do paměti vlastněné aplikací.
- Považujte export za úspěšný pouze když operace uložení prezentace vrátí a každé zpětné volání úspěšně dokončí. Nepohrcujte chyby úložiště ani nespouštějte nepozorované zápisy na pozadí. Pokud se perzistence provede později, hlaste celkový úspěch až po úspěšném dokončení i tohoto kroku.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) také platí pro vlastní ukládač. Výchozí nastavení, `False`, vylučuje XAML dokumenty pro skryté snímky. Při předání `True` jsou zahrnuty i všechny zdroje potřebné pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jedno zpětné volání na snímek ani pevné pořadí volání.

### **Export do paměti a kontrola artefaktů**

Tento kompletní příklad načte `pres.pptx`, shromáždí všechny artefakty do slovníku v Pythonu s názvy a neměnnými `bytes` hodnotami a vypíše jejich název, typ a počet bajtů. Uchovává přesně dodané názvy. Duplicitní názvy označují sbírku jako neplatnou místo tichého přepsání artefaktu. Příklad tuto situaci kontroluje před použitím výsledků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Dekódujte pouze XAML a pouze když je potřeba textová inspekce.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Kontroly přípon jsou užitečné pro inspekci; uchovejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu nechte bajty beze změny. Použijte `bytes.decode` s UTF-8 jen pro XAML, který vyžaduje textové zpracování.

### **Zabalte shromážděné artefakty do ZIP archivu**

Tento samostatný příklad shromažďuje export, ověřuje jeho názvy a zapisuje původní bajty do ZIP archivu. Jedinečný název archivu odděluje souběžné úlohy exportu. Záznamy ZIP používají lomítka a zachovávají relativní adresáře. Nebezpečné názvy nebo názvy, které po normalizaci kolidují, odmítnou celý balíček před jeho zápisem.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Uzavření finalizuje adresář ZIP před oznámením úspěchu.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Příklad používá `zipfile.ZipFile` v Pythonu k zápisu jednoho lokálního archivu; samotný exportér neukládá volné XAML ani soubory obrázků. Pro vzdálené úložiště nahraďte fázi zápisu archivu nahráním shromážděných bytových polí. Použijte identifikátor exportní úlohy plus úplný relativní název artefaktu jako klíč blobu, nebo uložte identifikátor úlohy, relativní název a binární data do řádku databáze. Publikujte úlohu až po dokončení všech nahrávek nebo po potvrzení databázové transakce. Vyčistěte částečný výstup, pokud perzistence selže.

Pro velké prezentace může vlastní ukládač perzistentně uložit každý artefakt přímo do úložiště aplikace, aby se předešlo držení další kopie celého exportu v paměti aplikace. Udržujte každé zpětné volání synchronní z pohledu exportéru: vraťte se až po přijetí bajtů cílem a umožněte selhání dorazit k volajícímu.

### **Zachování názvů zdrojů a ověření odkazů**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovejte relativní adresáře. Nepoužívejte pouze `pathlib.Path.name`, pokud nejste si jisti, že každý vygenerovaný název je jedinečný a odkazy na zdroje zůstávají platné.
- Použijte validaci názvů specifickou pro cíl. Při zápisu volných souborů odmítejte kořenové cesty a segmenty pro průnik, vyřešte cíl pomocí `pathlib.Path.resolve` a ověřte, že zůstává pod určeným exportním adresářem, včetně oddělovače adresáře v kontrole obsahování. Použijte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Použijte oddělený ukládač a jmenný prostor úložiště pro každou exportní úlohu. Detekujte kolize po normalizaci oddělovačů a podle pravidel ohledně velikosti písmen cíle.
- Před publikací parsujte každý XAML dokument jako XML a kontrolujte jeho souborové odkazy na zdroje, např. atributy `Source` nebo `ImageSource` u obrázků. Vyřešte každé relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte vzniklý název úložiště a potvrďte, že odpovídající klíč v mapě, záznam ZIP nebo uložený objekt existuje. Externí URI a XAML výrazy zpracovávejte odděleně od relativních názvů souborů.

Například pokud `pres/Slide_1.xaml` odkazuje na `images/image1.png`, uložený zdroj musí být dostupný jako `pres/images/image1.png`. Pouze `image1.png` by přerušilo tento vztah. Pro objektové úložiště zachovejte stejnou strukturu pod předponou úlohy a zajistěte, aby tyto URL zdrojů byly přístupné pro XAML spotřebitele. Znovu otevřete dokončený ZIP a ověřte názvy záznamů a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, abyste potvrdili, že obrázky se správně řeší.

## **Často kladené otázky**

**Jak mohu zajistit prediktabilní fonty, pokud originální font není na stroji dostupný?**

V [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/) zavolejte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveoptions/#setDefaultRegularFont). Tento font se použije jako náhradní během exportu, pokud originální chybí. To nezaručuje, že vygenerované XAML bude odkazovat na náhradní font nebo že font bude dostupný na cílovém stroji. Ujistěte se, že fonty, na které XAML odkazuje, jsou dostupné v prostředí, kde se zobrazují.

**Je exportované XAML určeno pouze pro WPF, nebo jej lze použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML prostřednictvím svého veřejného API. Kompatibilita s jinými XAML stacky, jako jsou UWP a Xamarin.Forms, není garantována. Otestujte vygenerované značkování ve vašem cílovém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Standardně jsou skryté snímky nezahrnuty. Toto chování můžete řídit pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) v [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/) — nechte jej zakázáno, pokud je nepotřebujete exportovat.