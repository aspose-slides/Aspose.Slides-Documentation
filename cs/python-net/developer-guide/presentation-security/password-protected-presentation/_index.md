---
title: Zabezpečení prezentací pomocí hesel v Pythonu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/python-net/password-protected-presentation/
keywords:
- uzamknout PowerPoint
- uzamknout prezentaci
- odemknout PowerPoint
- odemknout prezentaci
- chránit PowerPoint
- chránit prezentaci
- nastavit heslo
- přidat heslo
- šifrovat PowerPoint
- šifrovat prezentaci
- dešifrovat PowerPoint
- dešifrovat prezentaci
- ochrana proti zápisu
- bezpečnost PowerPoint
- bezpečnost prezentace
- odstranit heslo
- odstranit ochranu
- odstranit šifrování
- zakázat heslo
- zakázat ochranu
- odebrat ochranu proti zápisu
- prezentace PowerPoint
- Python
- Aspose.Slides
description: "Naučte se snadno zamykat a odemykat prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro Python přes .NET. Zvýšte svou produktivitu a zabezpečte své prezentace pomocí našeho průvodce krok za krokem."
---
## **Úvod**

Když zabezpečíte prezentaci heslem, nastavíte heslo, které vynutí určitá omezení na prezentaci. Pro odebrání omezení je nutné zadat heslo. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Obvykle můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úpravy**

  Pokud chcete, aby pouze určité uživatele mohli upravovat vaši prezentaci, můžete nastavit omezení úprav. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat obsah vaší prezentace (pokud neposkytnou heslo). 

  Avšak v tomto případě bude uživatel i bez hesla schopen přistupovat k vašemu dokumentu a otevřít jej. V režimu jen pro čtení může uživatel prohlížet obsah – hypertextové odkazy, animace, efekty a další – ve vaší prezentaci, ale nemůže kopírovat položky ani uložit prezentaci. 

- **Otevření**

  Pokud chcete, aby pouze určité uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec zobrazit obsah vaší prezentace (pokud neposkytnou heslo).

  Technicky omezení otevření také zabraňuje uživatelům upravovat vaši prezentaci: pokud lidé nemohou prezentaci otevřít, nemohou ji upravovat ani provádět změny. 
  
  **Poznámka** že když zabezpečíte prezentaci heslem tak, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## Jak online zabezpečit prezentaci heslem

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Drop or upload your files**.

3. Vyberte soubor, který chcete na svém počítači zabezpečit heslem. 

4. Zadejte požadované heslo pro ochranu úprav; Zadejte požadované heslo pro ochranu prohlížení. 

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální verzi, zaškrtněte políčko **Mark as final**.

6. Klikněte na **PROTECT NOW.** 

7. Klikněte na **DOWNLOAD NOW.**

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech: 

- PPTX a PPT – Microsoft PowerPoint Presentation 
- ODP – OpenDocument Presentation 
- OTP – OpenDocument Presentation Template 

**Podporované operace**

Aspose.Slides vám umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Další operace**

Aspose.Slides vám umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření šifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odebrání ochrany proti zápisu z prezentace
- Získání vlastností šifrované prezentace
- Kontrola, zda je prezentace šifrovaná
- Kontrola, zda je prezentace chráněna heslem.

## **Šifrování prezentace**

Můžete šifrovat prezentaci nastavením hesla. Pak, aby uživatel mohl upravit uzamčenou prezentaci, musí zadat heslo. 

Pro šifrování nebo zabezpečení prezentace heslem musíte použít metodu encrypt (z [ProtectionManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/)) k nastavení hesla pro prezentaci. Heslo předáte metodě encrypt a použijete metodu save k uložení nyní šifrované prezentace. 

Tento ukázkový kód ukazuje, jak šifrovat prezentaci:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení ochrany proti zápisu na prezentaci** 

Můžete přidat k prezentaci označení „Do not modify“. Tímto způsobem můžete uživatelům sdělit, že nechcete, aby prováděli změny v prezentaci.  

**Poznámka** že proces ochrany proti zápisu nešifruje prezentaci. Proto uživatelé – pokud to skutečně chtějí – mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit prezentaci s jiným názvem. 

Pro nastavení ochrany proti zápisu musíte použít metodu setWriteProtection. Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Dešifrování prezentace; Otevření šifrované prezentace**

Aspose.Slides umožňuje načíst šifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [remove_encryption](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/) bez parametrů. Pak budete muset zadat správné heslo pro načtení prezentace. 

Tento ukázkový kód ukazuje, jak dešifrovat prezentaci: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Odstranění šifrování; Vypnutí ochrany heslem**

Můžete odebrat šifrování nebo ochranu heslem na prezentaci. Tímto způsobem mohou uživatelé přistupovat k prezentaci nebo ji upravovat bez omezení. 

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [remove_encryption](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/). Tento ukázkový kód ukazuje, jak odebrat šifrování z prezentace:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Odebrání ochrany proti zápisu z prezentace**

Můžete použít Aspose.Slides k odebrání ochrany proti zápisu použité na souboru prezentace. Tímto způsobem mohou uživatelé upravovat podle libosti – a nedostanou žádná varování při provádění takových úkolů.

Ochranu proti zápisu z prezentace můžete odebrat pomocí metody [remove_write_protection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/). Tento ukázkový kód ukazuje, jak odebrat ochranu proti zápisu z prezentace:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání vlastností šifrované prezentace**

Obvykle uživatelé mají potíže získat vlastnosti dokumentu šifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje zabezpečit prezentaci heslem a zároveň zachovat možnost uživatelů přistupovat k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides šifruje prezentaci, jsou také vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides vám to umožní.

Pokud chcete, aby uživatelé i nadále mohli přistupovat k vlastnostem šifrované prezentace, nastavte vlastnost `encrypt_document_properties` třídy [ProtectionManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/) na `False`. Tento ukázkový kód ukazuje, jak šifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem dokumentu:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Načíst pouze vlastnosti dokumentu ze šifrované prezentace**

Pro prozkoumání metadat šifrované prezentace bez načítání snímků či jiného obsahu vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/) a nastavte [only_load_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/only_load_document_properties/) na `True`. V tomto režimu Aspose.Slides ignoruje heslo a načte pouze veřejně přístupné vlastnosti dokumentu.

Následující příklad kódu čte vestavěné vlastnosti dokumentu a vypisuje vlastní vlastnosti dokumentu pomocí [Presentation.document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Načíst vestavěné vlastnosti dokumentu.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Vypsat vlastní vlastnosti dokumentu.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Tento postup funguje pouze pokud byly vlastnosti dokumentu při šifrování prezentace ponechány nešifrované (veřejné). Pokud jsou vlastnosti dokumentu šifrované, nastavení `only_load_document_properties` na `True` způsobí výjimku, protože v tomto režimu je heslo ignorováno. Pro přístup k šifrovaným vlastnostem dokumentu nebo načtení celé prezentace včetně snímků a dalšího obsahu, zadejte správnou hodnotu `password` v [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/).

## **Kontrola, zda je prezentace chráněna heslem před jejím načtením**

Před načtením prezentace můžete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načtení prezentace chráněné heslem bez zadání hesla.

Tento Python kód ukazuje, jak prozkoumat prezentaci a zjistit, zda je chráněna heslem (bez načtení samotné prezentace):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Kontrola, zda je prezentace šifrovaná**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace šifrovaná. K tomu můžete použít vlastnost [is_encrypted](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/), která vrací `True`, pokud je prezentace šifrovaná, nebo `False`, pokud šifrována není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace šifrovaná:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K tomu můžete použít vlastnost [is_write_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/), která vrací `True`, pokud je prezentace chráněna proti zápisu, nebo `False`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Ověření nebo potvrzení, že konkrétní heslo bylo použito k ochraně prezentace**

Možná budete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro ověření hesla. 

Tento ukázkový kód ukazuje, jak ověřit heslo:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # zkontrolujte, zda je "pass" shodné s
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Vrací `True`, pokud byla prezentace šifrována zadaným heslem. V opačném případě vrací `False`.

{{% alert color="primary" title="Viz také" %}} 
- [Digital Signature in PowerPoint](/slides/cs/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody Aspose.Slides podporuje?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Při použití nesprávného hesla je vyvolána výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Má práce s prezentacemi chráněnými heslem nějaký dopad na výkon?**

Proces šifrování a dešifrování může během otevírání a ukládání operací přinést mírné zatížení. Ve většině případů je tento dopad na výkon minimální a výrazně neovlivní celkovou dobu zpracování vašich úkolů s prezentacemi.