---
title: Licencování
type: docs
weight: 80
url: /cs/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- licenční soubor
- dočasná licence
- měřené licencování
- omezení evaluace
description: "Použijte souborovou, bajtovou nebo měřené licence v Aspose.Slides pro Python via Java a odstraňte omezení evaluačního režimu ve svých aplikacích."
---
## **Přehled**

Aspose.Slides for Python via Java může běžet v evaluačním režimu nebo s licencí. V evaluačním režimu přidá textové pole s vodoznakem hodnocení na každý snímek každé prezentace, kterou uloží, a zkracuje text, který váš kód čte z prezentací. Tento článek vysvětluje, jak použít licenci ze souboru nebo z bajtů a jak nakonfigurovat měřenou licenci.

Pro možnosti nákupu viz [Cenové informace](https://purchase.aspose.com/pricing/slides/family). Pro obecné otázky týkající se licencování a nákupu viz [Politiky nákupu a Časté dotazy](https://purchase.aspose.com/policies).

Pro omezení evaluačního režimu a návod, jak požádat o dočasnou licenci, viz [Vyhodnocení Aspose.Slides](/slides/cs/python-java/evaluate-aspose-slides/). Dočasnou licenci použijte stejným způsobem jako zakoupený licenční soubor.

## **O licenci**

Licenční soubor obsahuje informace, jako je název produktu, počet licencovaných vývojářů a datum vypršení předplatného. Soubor je digitálně podepsaný XML.

{{% alert color="warning" title="Warning" %}}
Neupravujte licenční soubor. I další zalomení řádku může zneplatnit jeho digitální podpis.
{{% /alert %}}

Licenci aplikujte jednou na aplikaci nebo proces, před vytvořením prezentací nebo prováděním dalších operací Aspose.Slides. Pro licenční soubor použijte třídu [License](https://reference.aspose.com/slides/python-java/aspose.slides/license/). Měřené licencování používá pár veřejného a soukromého klíče místo licenčního souboru.

## **Použití licence**

Následující příklady předpokládají, že Aspose.Slides pro Python via Java a jeho předpoklady jsou nainstalovány. Každý příklad je samostatný skript, který spustí JVM, importuje API a použije licenci. Ve vaší aplikaci provádějte operace s prezentacemi po aplikaci licence a JVM vypněte až po dokončení veškeré práce s Aspose.Slides.

### **Použití licence ze souboru**

Předávejte cestu k licenčnímu souboru metodě [License.setLicense](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicense). Nahraďte `Aspose.Slides.lic` cestou k vašemu licenčnímu souboru.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Provádějte operace s prezentací zde, před vypnutím JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpile.shutdownJVM()
```

Použijte přesný název souboru včetně jeho přípony. Například pokud se soubor jmenuje `Aspose.Slides.lic.xml`, zahrňte `.xml` do cesty. Absolutní cesta zabraňuje nejasnostem ohledně pracovního adresáře aplikace.

Příklad používá [License.isLicensed](https://reference.aspose.com/slides/python-java/aspose.slides/license/#isLicensed) k ověření, zda byla licence použita.

### **Použití licence z bajtů**

Použijte [License.setLicenseFromBytes](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicenseFromBytes), když je licence k dispozici jako bajty v Pythonu. Následující příklad přečte soubor v binárním režimu a zavře jej před použitím licence.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Proveďte operace s prezentací zde, před vypnutím JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Nechte původní bajty beze změny. Neukládejte, nepřeformátujte ani jinak neměňte obsah licence před jejím použitím.

## **Použití měřené licence**

Měřené licencování vás účtuje dle využití API. Po získání měřené licence použijte její veřejný a soukromý klíč pomocí [Metered.setMeteredKey](https://reference.aspose.com/slides/python-java/aspose.slides/metered/#setMeteredKey). Inicializujte objekt [Metered](https://reference.aspose.com/slides/python-java/aspose.slides/metered/) a klíče použijte jednorázově při spouštění aplikace.

Následující příklad načte klíče z proměnných prostředí `ASPOSE_METERED_PUBLIC_KEY` a `ASPOSE_METERED_PRIVATE_KEY`. Nastavte obě proměnné před spuštěním skriptu.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Proveďte operace s prezentací zde, před vypnutím JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Měřené licencování vyžaduje internetové připojení pro ověření klíčů a hlášení využití. Soukromý klíč uchovávejte mimo zdrojový kód a logy. Podrobnosti o připojení a fakturaci najdete v [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}

## **Často kladené otázky**

**Potřebuji po zakoupení licence nainstalovat jiný balíček?**

Ne. Licenci použijte na stejný balíček, který jste používali při evaluaci.

**Mám licenci použít pro každou prezentaci?**

Ne. Aplikujte ji jednou při spouštění aplikace, před vytvořením nebo načtením prezentací.

**Mohu přejmenovat licenční soubor?**

Ano. Použijte přesný nový název souboru ve svém kódu a nechte obsah souboru beze změny.

**Mohu použít dočasnou licenci s příkladem založeným na bajtech?**

Ano. Přečtěte dočasný licenční soubor jako bajty a použijte jej stejným způsobem jako zakoupenou licenci.