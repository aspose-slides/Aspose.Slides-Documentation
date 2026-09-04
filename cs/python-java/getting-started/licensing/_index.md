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
- omezení zkušební verze
description: "Použijte souborovou, bajtovou nebo měřenou licenci v Aspose.Slides pro Python přes Java a odstraňte omezení zkušební verze z vašich aplikací."
---
## **Přehled**

Aspose.Slides pro Python přes Java může běžet v režimu zkušební verze nebo s licencí. Tento článek vysvětluje, jak použít licenci ze souboru nebo z bajtů a jak nakonfigurovat měřené licencování.

Pro možnosti nákupu viz [Pricing Information](https://purchase.aspose.com/pricing/slides/cs/family). Pro obecné otázky ohledně licencování a nákupu viz [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

Pro omezení zkušební verze a způsob, jak požádat o dočasnou licenci, viz [Evaluate Aspose.Slides](/slides/cs/python-java/evaluate-aspose-slides/). Dočasnou licenci použijte stejným způsobem jako zakoupený licenční soubor.

## **O licenci**

Licenční soubor obsahuje informace jako název produktu, počet licencovaných vývojářů a datum vypršení předplatného. Soubor je digitálně podepsaný XML.

{{% alert color="warning" title="Varování" %}}
Neúpravujte licenční soubor. I další prázdný řádek může zneplatnit jeho digitální podpis.
{{% /alert %}}

Licenci aplikujte jednou na aplikaci nebo proces, před vytvořením prezentací nebo prováděním jiných operací Aspose.Slides. Pro licenční soubor použijte třídu [License](https://reference.aspose.com/slides/cs/python-java/aspose.slides/license/). Měřené licencování používá pár veřejného a soukromého klíče místo licenčního souboru.

## **Použití licence**

Následující příklady předpokládají, že Aspose.Slides pro Python přes Java a jeho předpoklady jsou nainstalovány. Každý příklad je samostatný skript, který spustí JVM, importuje API a použije licenci. Ve své aplikaci provádějte operace s prezentacemi až po aplikaci licence a JVM vypněte až po dokončení veškeré práce s Aspose.Slides.

### **Použití licence ze souboru**

Předávejte cestu k licenčnímu souboru metodě [License.setLicense](https://reference.aspose.com/slides/cs/python-java/aspose.slides/license/#setLicense). Nahraďte `Aspose.Slides.lic` cestou k vašemu licenčnímu souboru.

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
        # Zde provádějte operace s prezentacemi, před vypnutím JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Použijte přesný název souboru včetně jeho přípony. Například pokud se soubor jmenuje `Aspose.Slides.lic.xml`, zahrňte `.xml` v cestě. Absolutní cesta zabraňuje nejasnostem ohledně pracovního adresáře aplikace.

Příklad používá [License.isLicensed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/license/#isLicensed) pro kontrolu, zda byla licence použita.

### **Použití licence z bajtů**

Použijte [License.setLicenseFromBytes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/license/#setLicenseFromBytes), když je licence k dispozici jako Python bajty. Následující příklad načte soubor v binárním režimu a zavře jej před použitím licence.

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
        # Zde provádějte operace s prezentacemi, před vypnutím JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Uchovejte původní bajty beze změny. Neukládejte, nepřeformátovávejte ani jinak neprovádějte úpravy obsahu licence před jejím použitím.

## **Použití měřené licence**

Měřené licencování vám účtuje podle využití API. Po získání měřené licence aplikujte její veřejný a soukromý klíč pomocí [Metered.setMeteredKey](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/#setMeteredKey). Inicializujte objekt [Metered](https://reference.aspose.com/slides/cs/python-java/aspose.slides/metered/) a klíče aplikujte jednou při spuštění aplikace.

Následující příklad načítá klíče z proměnných prostředí `ASPOSE_METERED_PUBLIC_KEY` a `ASPOSE_METERED_PRIVATE_KEY`. Před spuštěním skriptu nastavte obě proměnné.

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
        # Zde provádějte operace s prezentacemi, před vypnutím JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Poznámka" %}}
Měřené licencování vyžaduje internetové připojení k ověření klíčů a odesílání informací o využití. Soukromý klíč uchovávejte mimo zdrojový kód a logy. Viz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) pro podrobnosti o připojení a fakturaci.
{{% /alert %}}

## **Často kladené otázky**

**Musím po zakoupení licence instalovat jiný balíček?**

Ne. Licenci použijte ve stejném balíčku, který jste používali během zkušební verze.

**Mám aplikovat licenci pro každou prezentaci?**

Ne. Aplikujte ji jednou při spuštění aplikace, před vytvořením nebo načtením prezentací.

**Mohu přejmenovat licenční soubor?**

Ano. V kódu použijte přesný nový název souboru a nechte obsah souboru beze změny.

**Mohu použít dočasnou licenci s příkladem založeným na bajtech?**

Ano. Načtěte dočasný licenční soubor jako bajty a aplikujte jej stejným způsobem jako zakoupenou licenci.