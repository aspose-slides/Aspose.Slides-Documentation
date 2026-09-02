---
title: Zabezpečené prezentace pomocí hesel v PHP
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/php-java/password-protected-presentation/
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
- bezpečnost PowerPointu
- bezpečnost prezentace
- odstranit heslo
- odstranit ochranu
- odstranit šifrování
- zakázat heslo
- zakázat ochranu
- odstranit ochranu zápisu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak snadno zamknout a odemknout prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro PHP. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, nastavujete heslo, které vynucuje určitá omezení na prezentaci. Pro odebrání omezení je nutné heslo zadat. Prezentace chráněná heslem se považuje za uzamčenou prezentaci.

Typicky můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úpravy**

  Pokud chcete, aby pouze určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úprav. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat obsah vaší prezentace (pokud neposkytnou heslo).

  V tomto případě však může uživatel i bez hesla přistupovat k vašemu dokumentu a otevřít jej. V režimu jen pro čtení může uživatel prohlížet obsah – hypertextové odkazy, animace, efekty a další – uvnitř vaší prezentace, ale nemůže kopírovat položky ani prezentaci uložit.

- **Otevírání**

  Pokud chcete, aby pouze určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevírání. Toto omezení zabraňuje lidem vůbec prohlížet obsah vaší prezentace (pokud neposkytnou heslo).

  Technicky omezení otevírání také zabraňuje uživatelům upravovat vaše prezentace: když lidé nemohou prezentaci otevřít, nemohou ji upravovat ani měnit.

  **Poznámka** že když chráníte prezentaci heslem, aby se zabránilo otevření, soubor prezentace se zašifruje.

## **Jak chránit prezentaci heslem online**

1. Přejděte na naši stránku [**Aspose.Slides Lock**](https://products.aspose.app/slides/cs/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Přetáhněte nebo nahrajte soubory**.

3. Vyberte soubor, který chcete chránit heslem, ve svém počítači.

4. Zadejte požadované heslo pro ochranu úprav; Zadejte požadované heslo pro ochranu zobrazení.

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Označit jako finální**.

6. Klikněte na **PROTECT NOW.**

7. Klikněte na **DOWNLOAD NOW.**

## **Ochrana heslem pro prezentace v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v těchto formátech:

- PPTX a PPT – Microsoft PowerPoint prezentace
- ODP – OpenDocument prezentace
- OTP – OpenDocument šablona prezentace

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích, aby se zabránilo úpravám těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany zápisu pro prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření zašifrované prezentace
- Odebrání šifrování; vypnutí ochrany heslem
- Odebrání ochrany zápisu z prezentace
- Získání vlastností zašifrované prezentace
- Kontrola, zda je prezentace zašifrovaná
- Kontrola, zda je prezentace chráněna heslem.

## **Zašifrovat prezentaci**

Můžete zašifrovat prezentaci nastavením hesla. Pak pro úpravu uzamčené prezentace musí uživatel zadat heslo.

Pro šifrování nebo ochranu prezentace heslem musíte použít metodu **encrypt** (z [ProtectionManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/)) k nastavení hesla pro prezentaci. Heslo předáte metodě **encrypt** a metodou **save** uložíte nyní zašifrovanou prezentaci.

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Nastavit ochranu zápisu pro prezentaci**

Můžete přidat poznámku „Neupravit“ do prezentace. Tímto způsobem informujete uživatele, že nechtějí provádět změny v prezentaci.

**Poznámka** že proces ochrany zápisu nešifruje prezentaci. Uživatelé – pokud to chtějí – mohou prezentaci upravit, ale pro uložení změn budou muset vytvořit soubor s jiným názvem.

Pro nastavení ochrany zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#setWriteProtection). Tento ukázkový kód ukazuje, jak nastavit ochranu zápisu pro prezentaci:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Načíst zašifrovanou prezentaci**

Aspose.Slides umožňuje načíst zašifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeEncryption) bez parametrů. Poté budete muset zadat správné heslo k načtení prezentace.

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # práce s dešifrovanou prezentací
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Odebrat šifrování z prezentace**

Můžete odstranit šifrování nebo ochranu heslem na prezentaci. Tím uživatelé získají možnost přístupu nebo úpravy prezentace bez omezení.

Pro odebrání šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeEncryption). Tento ukázkový kód ukazuje, jak odebrat šifrování z prezentace:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Odebrat ochranu zápisu z prezentace**

Můžete použít Aspose.Slides k odebrání ochrany zápisu použité na souboru prezentace. Tím uživatelé mohou upravovat podle libosti a neobdrží žádná varování při provádění takových úkolů.

Odebrat ochranu zápisu z prezentace můžete pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Tento ukázkový kód ukazuje, jak odebrat ochranu zápisu z prezentace:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Získat vlastnosti zašifrované prezentace**

Typicky mají uživatelé potíže získat vlastnosti dokumentu zašifrované nebo chráněné heslem prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost přístupu k jejím vlastnostem.

**Poznámka:** Ve výchozím nastavení, když Aspose.Slides zašifruje prezentaci, jsou také vlastnosti dokumentu prezentace chráněny heslem. Pokud potřebujete, aby byly vlastnosti dokumentu přístupné i po šifrování, Aspose.Slides to umožňuje.

Pokud chcete, aby uživatelé i nadále mohli získat přístup k vlastnostem zašifrované prezentace, předávejte `false` metodě [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem dokumentu:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Načíst pouze vlastnosti dokumentu ze zašifrované prezentace**

Chcete‑li prozkoumat metadata zašifrované prezentace bez načítání snímků nebo dalšího obsahu, vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/) a předávejte `true` metodě [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). V tomto režimu Aspose.Slides ignoruje heslo a načte pouze veřejně přístupné vlastnosti dokumentu.

Následující příklad kódu čte vestavěné i vlastní vlastnosti dokumentu pomocí [Presentation::getDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Přečíst vestavěné vlastnosti dokumentu.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Přečíst vlastní vlastnosti dokumentu.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Tento postup funguje pouze tehdy, když byly vlastnosti dokumentu při šifrování ponechány nešifrované (veřejné). Pokud jsou vlastnosti dokumentu zašifrovány, předání `true` metodě [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) způsobí výjimku, protože v tomto režimu je heslo ignorováno. Pro přístup k zašifrovaným vlastnostem dokumentu nebo načtení kompletní prezentace, včetně snímků a dalšího obsahu, zadejte správné heslo pomocí [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword).

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace můžete chtít ověřit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načítání prezentace bez hesla.

Tento PHP kód ukazuje, jak zkontrolovat, zda je prezentace chráněna heslem (bez načtení samotné prezentace):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Zkontrolovat, zda je prezentace zašifrována**

Aspose.Slides umožňuje zjistit, zda je prezentace zašifrována. K provedení této úlohy můžete použít metodu [isEncrypted](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isEncrypted), která vrací `true`, pokud je prezentace zašifrována, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zjistit, zda je prezentace zašifrována:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Zkontrolovat, zda je prezentace chráněna proti zápisu**

Aspose.Slides umožňuje zjistit, zda je prezentace chráněna proti zápisu. K provedení této úlohy můžete použít metodu [isWriteProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isWriteProtected), která vrací `true`, pokud je prezentace chráněna, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zjistit, zda je prezentace chráněna proti zápisu:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ověřit, že byl použit konkrétní heslo**

Možná budete chtít zkontrolovat a potvrdit, že byl použit konkrétní heslo k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky pro ověření hesla.

Tento ukázkový kód ukazuje, jak ověřit heslo:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # zkontrolovat, zda se "pass" shoduje s
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Vrací `true`, pokud byla prezentace zašifrována zadaným heslem. V opačném případě vrací `false`.

{{% alert color="primary" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaké šifrovací metody jsou podporovány v Aspose.Slides?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení dat vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

Je vyvolána výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neautorizovanému přístupu a chrání obsah prezentace.

**Existují výkonnostní dopady při práci s prezentacemi chráněnými heslem?**

Proces šifrování a dešifrování může během otevírání a ukládání zavést mírné zatížení. Ve většině případů je tento dopad minimální a významně neovlivňuje celkový čas zpracování úloh s prezentacemi.