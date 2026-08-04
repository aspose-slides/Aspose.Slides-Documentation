---
title: Zabezpečené prezentace pomocí hesel v C++
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
- ochrana před zápisem
- bezpečnost PowerPoint
- bezpečnost prezentace
- odstranit heslo
- odstranit ochranu
- odstranit šifrování
- zakázat heslo
- zakázat ochranu
- odstranit ochranu před zápisem
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Naučte se snadno zamykat a odemykat prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro C++. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, nastavujete heslo, které vynucuje určitá omezení na prezentaci. Pro odstranění omezení je nutné heslo zadat. Prezentace chráněná heslem je považována za uzamčenou prezentaci.

Obvykle můžete nastavit heslo, které tato omezení na prezentaci vynutí:

- **Změna**

  Pokud chcete, aby jen určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úprav. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat obsah vaší prezentace (pokud neuvedou heslo).

  V tomto případě však uživatel bez hesla bude moci dokument otevřít a zobrazit jej v režimu jen pro čtení. Uživateli se zobrazí obsah – hypertextové odkazy, animace, efekty a další – ale nemůže kopírovat položky ani uložit prezentaci.

- **Otevření**

  Pokud chcete, aby jen určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec zobrazit obsah prezentace (pokud neuvedou heslo).

  Technicky omezení otevření také zabraňuje uživatelům upravovat prezentaci: Když lidé nemohou prezentaci otevřít, nemohou ji měnit ani provádět změny.

  **Poznámka**: Když chráníte prezentaci heslem tak, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Jak chránit prezentaci heslem online**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Drop or upload your files**.

3. Vyberte soubor, který chcete chránit heslem, ve svém počítači.

4. Zadejte požadované heslo pro ochranu úprav; Zadejte požadované heslo pro ochranu zobrazení.

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Mark as final**.

6. Klikněte na **PROTECT NOW**.

7. Klikněte na **DOWNLOAD NOW**.

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám těmito způsoby:

- Šifrování prezentace  
- Nastavení ochrany před zápisem pro prezentaci  

**Další operace**

Aspose.Slides umožňuje provádět další úlohy související s ochranou heslem a šifrováním takto:

- Dešifrování prezentace; otevření zašifrované prezentace  
- Odstranění šifrování; deaktivace ochrany heslem  
- Odstranění ochrany před zápisem z prezentace  
- Získání vlastností zašifrované prezentace  
- Kontrola, zda je prezentace zašifrována  
- Kontrola, zda je prezentace chráněna heslem  

## **Zašifrovat prezentaci**

Můžete zašifrovat prezentaci nastavením hesla. Pak uživatel, který chce upravit uzamčenou prezentaci, musí heslo zadat.

Pro šifrování nebo ochranu heslem prezentace použijte metodu encrypt (z třídy [ProtectionManager](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager)). Heslo předáte metodě encrypt a pomocí metody save uložíte nyní zašifrovanou prezentaci.

Níže je ukázkový kód, který ukazuje, jak prezentaci zašifrovat:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Nastavit ochranu před zápisem pro prezentaci**

Můžete přidat značku „Do not modify“ (Upravit zakázáno) do prezentace. Tímto způsobem můžete uživatelům sdělit, že nechcete, aby prováděli změny v prezentaci.

**Poznámka**: Proces ochrany před zápisem nešifruje prezentaci. Uživatelé – pokud opravdu chtějí – mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit soubor s jiným názvem.

Pro nastavení ochrany před zápisem použijte metodu setWriteProtection. Tento ukázkový kód ukazuje, jak nastavit ochranu před zápisem pro prezentaci:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Načíst zašifrovanou prezentaci**

Aspose.Slides umožňuje načíst zašifrovaný soubor předáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) bez parametrů. Poté budete muset zadat správné heslo pro načtení prezentace.

Níže je ukázkový kód, který ukazuje, jak dešifrovat prezentaci:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// práce s odšifrovanou prezentací
```

## **Odstranit šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem z prezentace. Tímto způsobem uživatelé získají přístup k prezentaci nebo ji mohou upravovat bez omezení.

Pro odstranění šifrování nebo ochrany heslem zavolejte metodu [RemoveEncryption](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Odstranit ochranu před zápisem z prezentace**

Můžete použít Aspose.Slides k odstranění ochrany před zápisem použité na soubor prezentace. Tímto způsobem mohou uživatelé upravovat podle libosti a neobdrží žádná varování při provádění takových úkolů.

Ochranu před zápisem z prezentace odstraníte pomocí metody [RemoveWriteProtection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Tento ukázkový kód ukazuje, jak odstranit ochranu před zápisem z prezentace:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Získat vlastnosti zašifrované prezentace**

Obvykle uživatelé mají potíže získat vlastnosti dokumentu zašifrované nebo chráněné heslem prezentace. Aspose.Slides však poskytuje mechanismus, který umožňuje chránit prezentaci heslem a současně umožnit přístup k jejím vlastnostem dokumentu.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou také vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides to umožňuje.

Pokud chcete, aby uživatelé i nadále mohli přistupovat k vlastnostem zašifrované prezentace, předaďte `false` metodě `set_EncryptDocumentProperties` rozhraní [IProtectionManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprotectionmanager/). Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a přitom uživatelům umožnit přístup k jejím vlastnostem dokumentu:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Načíst pouze vlastnosti dokumentu z zašifrované prezentace**

Chcete‑li prozkoumat metadata zašifrované prezentace, aniž byste načetli snímky nebo jiný obsah, vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/) a nastavte [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) na `true`. V tomto režimu Aspose.Slides ignoruje heslo a načte pouze veřejně přístupné vlastnosti dokumentu.

Následující ukázka kódu čte vestavěné i uživatelské vlastnosti dokumentu pomocí [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Tento postup funguje pouze v případě, že byly vlastnosti dokumentu při šifrování ponechány nezašifrované (veřejné). Pokud jsou vlastnosti dokumentu zašifrovány, nastavení `LoadOptions::set_OnlyLoadDocumentProperties` na `true` způsobí výjimku, protože v tomto režimu je heslo ignorováno. Pro přístup k zašifrovaným vlastnostem dokumentu nebo pro načtení celé prezentace, včetně snímků a dalšího obsahu, poskytněte správné heslo pomocí `LoadOptions::set_Password` v [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace možná budete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou, když je prezentace chráněná heslem načtena bez hesla.

Tento C++ kód ukazuje, jak analyzovat prezentaci a zjistit, zda je chráněna heslem (bez načtení samotné prezentace):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Zkontrolovat, zda je prezentace zašifrována**

Aspose.Slides umožňuje zkontrolovat, zda je prezentace zašifrována. K tomuto úkolu můžete použít metodu [get_IsEncrypted()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace zašifrována:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K tomuto úkolu můžete použít metodu [get_IsWriteProtected()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Ověřit použití hesla v prezentaci**

Možná budete chtít ověřit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro validaci hesla.

Tento ukázkový kód ukazuje, jak validovat heslo:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// zkontrolujte, zda "pass" odpovídá
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Vrací `true`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrací `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/cs/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody Aspose.Slides podporuje?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, čímž zajišťuje vysokou úroveň zabezpečení dat vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Vyvolá se výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá předcházet neoprávněnému přístupu a chrání obsah prezentace.

**Mají prezentace chráněné heslem dopad na výkon?**

Proces šifrování a dešifrování může během operací otevírání a ukládání způsobit mírný overhead. Ve většině případů je tento dopad na výkon minimální a významně neovlivňuje celkovou dobu zpracování úkolů s prezentacemi.