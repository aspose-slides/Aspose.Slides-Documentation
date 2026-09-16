---
title: Export prezentací do XAML pomocí Pythonu
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/python-net/export-to-xaml/
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
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML pomocí Pythonu a Aspose.Slides - rychlé řešení bez Office, které zachová váš rozvržení."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je jazyk založený na XML sloužící k popisu uživatelských rozhraní v rámcích jako WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin.Forms.

Můžete pracovat se soubory XAML ve vizuálním návrháři nebo psát a upravovat značkovací jazyk přímo.

## **Exportovat prezentace do XAML s výchozími možnostmi**

Následující příklad v Pythonu ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Ve výchozím nastavení jsou exportované snímky uloženy do podadresáře `pres` aktuálního pracovního adresáře procesu, jak vrací [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Adresář je vytvořen automaticky a všechny potřebné obrázky jsou také uloženy tam.

Název výstupního adresáře je odvozen od názvu zdrojového souboru bez přípony. Pro `pres.pptx` jsou výstupní soubory pojmenovány `pres/Slide_1.xaml`, `pres/Slide_2.xaml` a tak dále. I když zadáte absolutní cestu k vstupní prezentaci, výstupní adresář je vytvořen relativně k aktuálnímu pracovnímu adresáři, nikoli vedle vstupního souboru.

## **Exportovat prezentace do XAML s vlastními možnostmi**

Použijte třídu [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/) k řízení toho, jak Aspose.Slides exportuje prezentaci do XAML.

Aby byly skryté snímky zahrnuty do výstupu XAML, nastavte vlastnost [export_hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) na `True`, jak je ukázáno v následujícím příkladu v Pythonu:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Zachytit všechny vygenerované artefakty XAML**

Export XAML může vytvořit XAML dokument pro každý exportovaný snímek plus samostatné obrázky a podpůrné zdroje. Uchovávejte všechny tyto soubory při ukládání nebo přenosu exportu.

Následující příklady používají výchozí ukladač souborového systému v dočasném adresáři a poté shromažďují vygenerované soubory.

### **Pochopit životní cyklus exportu**

- Zahajte export pomocí XAML‑specifické přetížení [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) , které přijímá XAML možnosti. Načtěte vygenerované soubory až po úspěšném návratu.
- Zachovejte relativní cestu každého artefaktu, protože XAML může odkazovat na zdroje pomocí relativních cest.
- Čtěte artefakty jako bajty. Obrázky a další binární zdroje nesmí být dekódovány jako text.
- Zpráva o celkovém úspěchu by měla být odeslána až po dokončení sběru a jakékoli následné operace ukládání. Nechte chyby ukládání dostat se k volajícímu a vyčistěte částečný výstup, pokud ukládání selže.

`[XamlOptions.export_hidden_slides]` má ve výchozím nastavení `False`, což vylučuje XAML dokumenty skrytých snímků. Nastavením na `True` je zahrne spolu se všemi zdroji potřebnými pro jejich export. Počet zdrojů závisí na prezentaci; nepředpokládejte jeden soubor na snímek.

{{% alert color="warning" title="Upozornění" %}}
Příklady dočasně mění aktuální pracovní adresář procesu, což ovlivňuje všechny vlákna. Spouštějte každý export v samostatném pracovním procesu, nebo zajistěte, aby žádná jiná činnost v procesu nebyla během exportu závislá na aktuálním adresáři. Pouze jedinečný dočasný adresář nezajistí bezpečnost souběžných exportů ve stejném procesu.
{{% /alert %}}

### **Exportovat do paměti a prozkoumat artefakty**

Kompletní příklad načte `pres.pptx`, exportuje jej do dočasného adresáře, shromáždí každý artefakt ve slovníku relativních názvů a bajtů a vypíše jeho název, typ a počet bajtů. Zachovává vytvořenou strukturu adresářů a po sběru odstraní dočasné soubory. Vstupní cesta je vyřešena před změnou pracovního adresáře.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Dekódujte pouze XAML a jen když je potřeba textová kontrola.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Kontrola přípon je užitečná pro inspekci; zachovejte všechny artefakty, včetně neznámých typů zdrojů. Při ukládání nebo přenosu ponechte bajty beze změny. Dekódujte pouze XAML, který vyžaduje textové zpracování. Tento přístup využívá dočasný diskový prostor i paměť pro shromážděný export.

### **Zabalit shromážděné artefakty do ZIP archivu**

Samostatný příklad shromáždí export, ověří jeho názvy a zapíše původní bajty do ZIP archivu. Jedinečný název archivu odděluje úlohy exportu. položky ZIP používají dopředná lomítka a zachovávají relativní adresáře. Nebezpečné názvy nebo názvy, které po normalizaci kolidují, odmítnou celý balík před zápisem.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Adresář ZIP byl dokončen před nahlášením úspěchu.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Příklad používá [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile), aby po shromáždění dočasného exportu zapsal jeden lokální archiv. Pro vzdálené ukládání nahraďte fázi zápisu archivu nahráváním shromážděných bajtů. Použijte identifikátor úlohy exportu plus úplný relativní název artefaktu jako klíč objektu, nebo uložte identifikátor úlohy, relativní název a binární data do řádku databáze. Publikujte úlohu až po dokončení všech nahrávek nebo po potvrzení transakce databáze. Vyčistěte částečný výstup, pokud ukládání selže.

U velkých prezentací zpracovávejte dočasné soubory po jednom po exportu místo shromažďování všech jejich bajtů do slovníku. Tím se vyhnete dalšímu kopírování celého exportu v paměti, ale neodstraní požadavky exportéra na paměť.

### **Zachovat názvy zdrojů a ověřit odkazy**

- Normalizujte oddělovače cest, pokud to cíl vyžaduje, ale zachovejte relativní adresáře. Neuchovávejte pouze konečný název souboru, pokud není jisté, že každý vygenerovaný název je unikátní a odkazy na zdroje zůstávají platné.
- Používejte validaci názvů specifickou pro cíl. Při zápisu volných souborů odmítejte absolutní cesty a segmenty pro průnik, vyřešte cíl a ověřte, že zůstává pod zamýšleným exportním adresářem. Používejte adresář řízený aplikací bez symbolických odkazů, které by mohly přesměrovat zápisy.
- Pro každou úlohu exportu použijte samostatný úložný jmenný prostor. Detekujte kolize po normalizaci oddělovačů a podle pravidel citlivosti na velikost písmen cíle.
- Před publikací analyzujte každý XAML dokument jako XML a prozkoumejte jeho reference na souborové zdroje, jako jsou atributy obrázku `Source` nebo `ImageSource`. Rozřešte každý relativní URI vůči adresáři obsahujícímu XAML artefakt, normalizujte vzniklý název úložiště a potvrďte, že odpovídající klíč ve slovníku, položka ZIP nebo uložený objekt existuje. Zacházejte s externími URI a XAML značkovacími výrazy odděleně od relativních názvů souborů.

Příklad: pokud `pres/Slide_1.xaml` odkazuje na `images/image1.png`, uložený zdroj musí být dostupný jako `pres/images/image1.png`. Uchování pouze `image1.png` by vztah narušilo. Pro objektové úložiště zachovejte stejnou strukturu pod prefixem úlohy a zpřístupněte tyto URL zdrojů pro spotřebitele XAML. Znovu otevřete dokončený ZIP a ověřte názvy položek a bajty zdrojů a načtěte reprezentativní snímky v cílovém XAML prostředí, abyste potvrdili, že obrázky jsou správně rozpoznány.

## **Často kladené otázky**

**Jak mohu zajistit předvídatelné fonty, pokud původní font není na počítači dostupný?**

Nastavte [default_regular_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) v [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/) — během exportu se použije jako náhradní font, pokud původní chybí. To však nezaručuje, že vygenerované XAML bude odkazovat na náhradní font nebo že bude font dostupný na cílovém počítači. Ujistěte se, že fonty odkázané v XAML jsou dostupné v prostředí, kde je zobrazeno.

**Je exportované XAML určeno pouze pro WPF, nebo jej lze použít i v jiných XAML stackech?**

Aspose.Slides exportuje WPF XAML prostřednictvím svého veřejného API. Kompatibilita s jinými XAML stacky, jako jsou UWP a Xamarin.Forms, není zaručena. Otestujte vygenerované značky ve vašem cílovém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [export_hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) v [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/) — nechte jej zakázáno, pokud je nepotřebujete exportovat.