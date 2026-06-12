---
title: Zabezpečte prezentace pomocí hesel v C++
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/cpp/password-protected-presentation/
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
- ochrana proti zápisu
- zabezpečení PowerPoint
- zabezpečení prezentace
- odstranit heslo
- odstranit ochranu
- odstranit šifrování
- zakázat heslo
- zakázat ochranu
- odstranit ochranu proti zápisu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se snadno zamykat a odemykat prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro C++. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, nastavujete heslo, které vynutí určitá omezení na prezentaci. Pro odstranění omezení je třeba zadat heslo. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Typicky můžete nastavit heslo, aby vynutilo tato omezení na prezentaci:

- **Úprava**

  Pokud chcete, aby jen určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení brání lidem upravovat, měnit nebo kopírovat obsah vaší prezentace (pokud neposkytnou heslo).  

  V tomto případě však i bez hesla může uživatel dokument otevřít a získat přístup. V režimu jen ke čtení může uživatel zobrazit obsah – hypertextové odkazy, animace, efekty a další – v prezentaci, ale nemůže kopírovat položky ani prezentaci uložit. 

- **Otevření**

  Pokud chcete, aby jen určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení brání lidem vůbec zobrazit obsah vaší prezentace (pokud neposkytnou heslo).

  Technicky omezení otevření také zabraňuje uživatelům v úpravách vašich prezentací: pokud lidé nemohou prezentaci otevřít, nemohou ji ani upravovat.  
  
  **Poznámka**: když chráníte prezentaci heslem, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Jak chránit prezentaci heslem online**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Přetáhněte nebo nahrajte soubory**.

3. Vyberte soubor, který chcete chránit heslem, na svém počítači. 

4. Zadejte požadované heslo pro ochranu úprav; Zadejte požadované heslo pro ochranu zobrazení. 

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Označit jako finální**.

6. Klikněte na **CHRÁNIT NYNÍ.** 

7. Klikněte na **STÁHNOUT NYNÍ.**

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech: 

- PPTX a PPT – Microsoft PowerPoint prezentace 
- ODP – OpenDocument prezentace 
- OTP – Šablona OpenDocument prezentace 

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích k zabránění úprav těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu na prezentaci

**Ostatní operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Zašifrovat prezentaci**

Můžete prezentaci zašifrovat nastavením hesla. Poté aby uživatel mohl upravit uzamčenou prezentaci, musí zadat heslo. 

Pro zašifrování nebo ochranu prezentace heslem musíte použít metodu encrypt (z [ProtectionManager](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager)) k nastavení hesla pro prezentaci. Heslo předáte metodě encrypt a použijete metodu save k uložení nyní zašifrované prezentace. 

Tento ukázkový kód ukazuje, jak prezentaci zašifrovat:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Nastavit ochranu proti zápisu na prezentaci** 

Můžete přidat poznámku “Nesměte měnit” k prezentaci. Tím dáte uživatelům najevo, že si nepřejete, aby prováděli změny v prezentaci.  

**Poznámka**: proces ochrany proti zápisu nešifruje prezentaci. Proto uživatelé — pokud chtějí — mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit prezentaci s jiným názvem. 

Pro nastavení ochrany proti zápisu musíte použít metodu setWriteProtection. Tento ukázkový kód vám ukazuje, jak nastavit ochranu proti zápisu na prezentaci:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Načíst zašifrovanou prezentaci**

Aspose.Slides vám umožňuje načíst šifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) bez parametrů. Poté budete muset zadat správné heslo pro načtení prezentace. 

Tento ukázkový kód ukazuje, jak dešifrovat prezentaci: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// pracujte s dešifrovanou prezentací
```

## **Odstranit šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace. Tím umožníte uživatelům přístup nebo úpravu prezentace bez omezení. 

Pro odstranění šifrování nebo ochrany heslem musíte zavolat metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Odstranit ochranu proti zápisu z prezentace**

Můžete použít Aspose.Slides k odstranění ochrany proti zápisu použité na souboru prezentace. Tím uživatelé mohou upravovat dle své libosti – a nebudou dostávat žádná varování při provádění takových úkolů.

Ochranu proti zápisu z prezentace můžete odstranit pomocí metody [RemoveWriteProtection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Získat vlastnosti zašifrované prezentace**

Obvykle mají uživatelé potíže získat vlastnosti dokumentu zašifrované nebo heslem chráněné prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a přitom zachovat možnost, aby uživatelé mohli přistupovat k jejím vlastnostem.  

**Poznámka**: když Aspose.Slides zašifruje prezentaci, jsou také výchozím způsobem chráněny heslem vlastnosti dokumentu prezentace. Pokud však potřebujete, aby byly vlastnosti prezentace přístupné (i po zašifrování prezentace), Aspose.Slides vám to umožní. 

Pokud chcete, aby uživatelé zachovali možnost přístupu k vlastnostem prezentace, kterou jste zašifrovali, můžete předat `true` metodě [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace možná budete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načtení prezentace chráněné heslem bez zadání hesla.

Tento C++ kód ukazuje, jak prozkoumat prezentaci a zjistit, zda je chráněna heslem (bez načtení samotné prezentace):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Zkontrolovat, zda je prezentace zašifrována**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace zašifrována. K tomu můžete použít metodu [get_IsEncrypted()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není. 

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides vám umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K tomu můžete použít metodu [get_IsWriteProtected()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není. 

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Ověřit použití hesla v prezentaci**

Můžete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky k ověření hesla. 

Tento ukázkový kód ukazuje, jak ověřit heslo:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// zkontrolujte, zda je "pass" shodné s
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Vrací `true`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrací `false`. 

{{% alert color="primary" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaké šifrovací metody jsou podporovány Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Pokud je zadáno nesprávné heslo, vyvolá se výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Má práce s prezentacemi chráněnými heslem dopad na výkon?**

Proces šifrování a dešifrování může během otevírání a ukládání operací způsobit mírné zatížení. Ve většině případů je tento dopad na výkon minimální a výrazně neovlivňuje celkovou dobu zpracování úloh s vaší prezentací.