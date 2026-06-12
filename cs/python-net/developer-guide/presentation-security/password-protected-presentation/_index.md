---
title: Zabezpečení prezentací pomocí hesel v Pythonu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/python-net/password-protected-presentation/
keywords:
- zamknout PowerPoint
- zamknout prezentaci
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
- ochrana zápisu
- bezpečnost PowerPoint
- bezpečnost prezentace
- odstranit heslo
- odstranit ochranu
- odstranit šifrování
- zakázat heslo
- zakázat ochranu
- odstranit ochranu zápisu
- prezentace PowerPoint
- Python
- Aspose.Slides
description: "Naučte se snadno zamykat a odemykat prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro Python přes .NET. Zvýšte svou produktivitu a zabezpečte své prezentace pomocí našeho krok za krokem průvodce."
---
## **Úvod**

Když prezentaci chráníte heslem, nastavujete heslo, které vynucuje určitá omezení na prezentaci. Pro odstranění omezení je třeba zadat heslo. Prezentace chráněná heslem je považována za zamčenou prezentaci.

Typicky můžete nastavit heslo, aby byla tato omezení v prezentaci vynucena:

- **Úpravy**

  Pokud chcete, aby pouze určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úprav. Toto omezení brání lidem v úpravě, změně nebo kopírování věcí ve vaší prezentaci (pokud nezadají heslo).

  Nicméně v tomto případě bude uživatel i bez hesla schopen přistupovat k vašemu dokumentu a otevřít jej. V režimu jen pro čtení může uživatel zobrazit obsah nebo prvky — hyperlinky, animace, efekty a další — uvnitř vaší prezentace, ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevření**

  Pokud chcete, aby pouze určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení brání lidem v samotném zobrazení obsahu vaší prezentace (pokud nezadají heslo).

  Technicky omezení otevření také zabraňuje uživatelům v úpravě vašich prezentací: když lidé nemohou prezentaci otevřít, nemohou ji ani upravovat.

  **Poznámka** že když chráníte prezentaci heslem, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## Jak chránit prezentaci heslem online

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Drop or upload your files**.

3. Vyberte soubor, který chcete chránit heslem, ve svém počítači.

4. Zadejte požadované heslo pro ochranu úprav; zadejte požadované heslo pro ochranu zobrazení.

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Mark as final**.

6. Klikněte na **PROTECT NOW.**

7. Klikněte na **DOWNLOAD NOW.**

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT — Microsoft PowerPoint Presentation
- ODP — OpenDocument Presentation
- OTP — OpenDocument Presentation Template

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám následujícími způsoby:

- Šifrování prezentace
- Nastavení ochrany zápisu na prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Šifrování prezentace**

Můžete prezentaci zašifrovat nastavením hesla. Pak, aby mohl uživatel upravit zamčenou prezentaci, musí zadat heslo.

Pro zašifrování nebo ochranu heslem prezentace musíte použít metodu **encrypt** (z [ProtectionManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/)) k nastavení hesla pro prezentaci. Heslo předáte metodě **encrypt** a pomocí metody **save** uložíte nyní zašifrovanou prezentaci.

Tento ukázkový kód vám ukazuje, jak prezentaci zašifrovat:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení ochrany zápisu na prezentaci**

Můžete do prezentace přidat značku „Do not modify“. Tímto způsobem informujete uživatele, že nechcete, aby prováděli změny v prezentaci.

**Poznámka** že proces ochrany zápisu nešifruje prezentaci. Proto mohou uživatelé — pokud skutečně chtějí — prezentaci upravit, ale pro uložení změn budou muset vytvořit prezentaci pod jiným názvem.

Pro nastavení ochrany zápisu musíte použít metodu **setWriteProtection**. Tento ukázkový kód vám ukazuje, jak nastavit ochranu zápisu na prezentaci:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Dešifrování prezentace; otevření zašifrované prezentace**

Aspose.Slides vám umožňuje načíst zašifrovaný soubor předáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [remove_encryption](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/) bez parametrů. Pak budete muset zadat správné heslo pro načtení prezentace.

Tento ukázkový kód vám ukazuje, jak dešifrovat prezentaci:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Odstranění šifrování; vypnutí ochrany heslem**

Můžete odstranit šifrování nebo ochranu heslem na prezentaci. Tímto způsobem budou uživatelé schopni prezentaci přistupovat nebo ji upravovat bez omezení.

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [remove_encryption](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranění ochrany zápisu z prezentace**

Můžete použít Aspose.Slides k odstranění ochrany zápisu použité na souboru prezentace. Tímto způsobem uživatelé mohou upravovat dle libosti — a nebudou dostávat žádná varování při provádění těchto úkolů.

Odebrání ochrany zápisu z prezentace provedete pomocí metody [remove_write_protection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/). Tento ukázkový kód ukazuje, jak odstranit ochranu zápisu z prezentace:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání vlastností zašifrované prezentace**

Obvykle uživatelé mají potíže získat vlastnosti dokumentu zašifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který vám umožní chránit prezentaci heslem a zároveň zachovat možnost přístupu uživatelů k vlastnostem této prezentace.

**Poznámka** že když Aspose.Slides zašifruje prezentaci, její vlastnosti dokumentu jsou také ve výchozím nastavení chráněny heslem. Pokud však potřebujete, aby byly vlastnosti prezentace přístupné (i po šifrování), Aspose.Slides vám to umožní.

Pokud chcete, aby uživatelé i nadále měli možnost přistupovat k vlastnostem prezentace, kterou jste zašifrovali, můžete nastavit vlastnost [EncryptDocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/) na `True`. Tento ukázkový kód ukazuje, jak prezentaci zašifrovat a zároveň umožnit uživatelům přístup k jejím vlastnostem:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Kontrola, zda je prezentace chráněna heslem před jejím načtením**

Před načtením prezentace možná budete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načtení prezentace chráněné heslem bez zadání hesla.

Tento Python kód vám ukazuje, jak zkoumat prezentaci a zjistit, zda je chráněna heslem (bez jejího načtení):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Kontrola, zda je prezentace zašifrována**

Aspose.Slides umožňuje zkontrolovat, zda je prezentace zašifrována. K provedení tohoto úkolu můžete použít vlastnost [is_encrypted](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/), která vrací `True`, pokud je prezentace zašifrována, nebo `False`, pokud není.

Tento ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Aspose.Slides umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít vlastnost [is_write_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/), která vrací `True`, pokud je prezentace zašifrována, nebo `False`, pokud není.

Tento ukázkový kód vám ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Ověření nebo potvrzení, že konkrétní heslo bylo použito k ochraně prezentace**

Možná budete chtít ověřit a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro validaci hesla.

Tento ukázkový kód vám ukazuje, jak validovat heslo:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # zkontrolujte, zda se "pass" shoduje s
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Vrací `True`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrací `False`.

{{% alert color="primary" title="Viz také" %}} 
- [Digital Signature in PowerPoint](/slides/cs/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody podporuje Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, a tím zajišťuje vysokou úroveň zabezpečení dat vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá předcházet neoprávněnému přístupu a chrání obsah prezentace.

**Mají ochrana heslem prezentací vliv na výkon?**

Proces šifrování a dešifrování může během otevírání a ukládání zavést mírné zatížení. Ve většině případů je tento dopad na výkon minimální a významně neovlivňuje celkovou dobu zpracování vašich úkolů s prezentacemi.