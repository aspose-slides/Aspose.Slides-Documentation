---
title: Zabezpečte prezentace pomocí hesel v PHP
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/php-java/password-protected-presentation/
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
- zabezpečení PowerPointu
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
- PHP
- Aspose.Slides
description: "Zjistěte, jak snadno zamknout a odemknout prezentace PowerPoint a OpenDocument chráněné heslem pomocí Aspose.Slides pro PHP. Zabezpečte své prezentace."
---
## **Úvod**

Když chráníte prezentaci heslem, nastavujete heslo, které vynutí určitá omezení na prezentaci. Pro odstranění omezení je nutné zadat heslo. Prezentace chráněná heslem se považuje za zamčenou prezentaci.

Obvykle můžete nastavit heslo, které vynutí tato omezení na prezentaci:

- **Úprava**

  Pokud chcete, aby jen určití uživatelé mohli upravovat vaši prezentaci, můžete nastavit omezení úpravy. Toto omezení zabraňuje lidem upravovat, měnit nebo kopírovat věci ve vaší prezentaci (pokud nezadají heslo). 

  Nicméně v tomto případě bude uživatel i bez hesla moci přistupovat k dokumentu a otevřít jej. V režimu jen pro čtení může uživatel zobrazit obsah nebo prvky – hypertextové odkazy, animace, efekty a další – ve vaší prezentaci, ale nemůže kopírovat položky ani prezentaci uložit. 

- **Otevření**

  Pokud chcete, aby jen určití uživatelé mohli otevřít vaši prezentaci, můžete nastavit omezení otevření. Toto omezení zabraňuje lidem vůbec zobrazit obsah vaší prezentace (pokud nezadají heslo).

  Technicky omezení otevření také zabraňuje uživatelům upravovat vaše prezentace: když lidé nemohou prezentaci otevřít, nemohou ji měnit ani provádět úpravy. 
  
  **Poznámka**: když chráníte prezentaci heslem, aby se zabránilo jejímu otevření, soubor prezentace se zašifruje.

## **Jak online chránit prezentaci heslem**

1. Přejděte na naši stránku [**Zámek Aspose.Slides**](https://products.aspose.app/slides/cs/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Klikněte na **Přetáhněte nebo nahrajte své soubory**.

3. Vyberte soubor, který chcete chránit heslem, ve svém počítači. 

4. Zadejte požadované heslo pro ochranu úprav; Zadejte požadované heslo pro ochranu zobrazení. 

5. Pokud chcete, aby uživatelé viděli vaši prezentaci jako finální kopii, zaškrtněte políčko **Označit jako finální**.

6. Klikněte na **CHRÁNIT NYNÍ.** 

7. Klikněte na **STÁHNOUT NYNÍ.**

## **Ochrana heslem prezentací v Aspose.Slides**
**Podporované formáty**

Aspose.Slides podporuje ochranu heslem, šifrování a podobné operace pro prezentace v následujících formátech: 

- PPTX a PPT – Microsoft PowerPoint prezentace 
- ODP – OpenDocument prezentace 
- OTP – OpenDocument šablona prezentace 

**Podporované operace**

Aspose.Slides umožňuje použít ochranu heslem na prezentacích k zabránění úprav těmito způsoby:

- Šifrování prezentace
- Nastavení ochrany proti zápisu pro prezentaci

**Další operace**

Aspose.Slides umožňuje provádět další úkoly související s ochranou heslem a šifrováním těmito způsoby:

- Dešifrování prezentace; otevření šifrované prezentace
- Odstranění šifrování; vypnutí ochrany heslem
- Odstranění ochrany proti zápisu z prezentace
- Získání vlastností šifrované prezentace
- Kontrola, zda je prezentace šifrována
- Kontrola, zda je prezentace chráněna heslem.

## **Zašifrovat prezentaci**

Můžete prezentaci zašifrovat nastavením hesla. Pak, aby uživatel mohl upravit zamčenou prezentaci, musí zadat heslo. 

Pro šifrování nebo ochranu prezentace heslem musíte použít metodu encrypt (z [ProtectionManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/)) k nastavení hesla pro prezentaci. Heslo předáte metodě encrypt a použijete metodu save pro uložení nyní zašifrované prezentace.

Tento ukázkový kód ukazuje, jak prezentaci zašifrovat:

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

## **Nastavit ochranu proti zápisu pro prezentaci**

Můžete do prezentace přidat značku s textem “Neupravovat”. Tímto způsobem uživatelům sdělíte, že si nepřejete, aby měnili prezentaci.  

**Poznámka**: proces ochrany proti zápisu nešifruje prezentaci. Uživatelé – pokud to skutečně chtějí – mohou prezentaci upravit, ale aby změny uložili, budou muset vytvořit novou prezentaci pod jiným názvem. 

Pro nastavení ochrany proti zápisu musíte použít metodu [setWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#setWriteProtection). Tento ukázkový kód ukazuje, jak nastavit ochranu proti zápisu pro prezentaci:

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

## **Načíst šifrovanou prezentaci**

Aspose.Slides umožňuje načíst šifrovaný soubor zadáním jeho hesla. Pro dešifrování prezentace musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeEncryption) bez parametrů. Poté budete muset zadat správné heslo pro načtení prezentace.

Tento ukázkový kód ukazuje, jak dešifrovat prezentaci: 

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

## **Odstranit šifrování z prezentace**

Můžete odebrat šifrování nebo ochranu heslem z prezentace. Tímto způsobem budou uživatelé moci přistupovat k prezentaci nebo ji upravovat bez omezení. 

Pro odebrání šifrování nebo ochrany heslem musíte zavolat metodu [removeEncryption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeEncryption). Tento ukázkový kód ukazuje, jak odstranit šifrování z prezentace:

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

## **Odstranit ochranu proti zápisu z prezentace**

Můžete použít Aspose.Slides k odstranění ochrany proti zápisu použité na souboru prezentace. Tímto způsobem mohou uživatelé upravovat dle libosti – a nedostanou žádná varování při provádění těchto úkolů.

Ochranu proti zápisu z prezentace můžete odstranit pomocí metody [removeWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Tento ukázkový kód ukazuje, jak odstranit ochranu proti zápisu z prezentace:

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

## **Získat vlastnosti šifrované prezentace**

Obvykle mají uživatelé potíže získat vlastnosti dokumentu šifrované nebo heslem chráněné prezentace. Aspose.Slides však nabízí mechanismus, který umožňuje chránit prezentaci heslem a zároveň zachovat možnost uživatelům přistupovat k vlastnostem této prezentace.

**Poznámka**: když Aspose.Slides šifruje prezentaci, jsou výchozí nastaveny i vlastnosti dokumentu prezentace pod heslem. Pokud však potřebujete, aby byly vlastnosti prezentace přístupné (i po zašifrování prezentace), Aspose.Slides vám to umožní.

Pokud chcete, aby uživatelé i po zašifrování prezentace měli možnost přistupovat k jejím vlastnostem, můžete použít metodu [encryptDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) s hodnotou `true`. Tento ukázkový kód ukazuje, jak zašifrovat prezentaci a zároveň umožnit uživatelům přístup k jejím vlastnostem dokumentu:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Zkontrolovat, zda je prezentace chráněna heslem**

Před načtením prezentace můžete chtít zkontrolovat a potvrdit, že prezentace není chráněna heslem. Tím se vyhnete chybám a podobným problémům, které nastanou při načítání prezentace chráněné heslem bez zadání hesla.

Tento PHP kód ukazuje, jak zkontrolovat prezentaci, zda je chráněna heslem (bez načítání samotné prezentace):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Zkontrolovat, zda je prezentace šifrována**

Aspose.Slides umožňuje zkontrolovat, zda je prezentace šifrována. K provedení tohoto úkolu můžete použít metodu [isEncrypted](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isEncrypted), která vrací `true`, pokud je prezentace šifrována, nebo `false`, pokud šifrována není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace šifrována:

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

Aspose.Slides umožňuje zkontrolovat, zda je prezentace chráněna proti zápisu. K provedení tohoto úkolu můžete použít metodu [isWriteProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isWriteProtected), která vrací `true`, pokud je prezentace chráněna proti zápisu, nebo `false`, pokud není.

Tento ukázkový kód ukazuje, jak zkontrolovat, zda je prezentace chráněna proti zápisu:

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

## **Ověřit nebo potvrdit, že bylo použito konkrétní heslo**

Možná budete chtít zkontrolovat a potvrdit, že konkrétní heslo bylo použito k ochraně dokumentu prezentace. Aspose.Slides poskytuje prostředky k ověření hesla. 

Tento ukázkový kód ukazuje, jak ověřit heslo:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # zkontrolujte, zda se "pass" shoduje s
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Vrátí `true`, pokud byla prezentace zašifrována uvedeným heslem. V opačném případě vrátí `false`. 

{{% alert color="primary" title="Viz také" %}} 
- [Digitální podpis v PowerPointu](/slides/cs/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaké šifrovací metody Aspose.Slides podporuje?**

Aspose.Slides podporuje moderní šifrovací metody, včetně algoritmů založených na AES, což zajišťuje vysokou úroveň zabezpečení dat vašich prezentací.

**Co se stane, když je při pokusu o otevření prezentace zadáno nesprávné heslo?**

V případě použití nesprávného hesla je vyvolána výjimka, která upozorní, že přístup k prezentaci byl odmítnut. To pomáhá zabránit neoprávněnému přístupu a chrání obsah prezentace.

**Mají prezentace chráněné heslem nějaké dopady na výkon?**

Proces šifrování a dešifrování může během otevírání a ukládání přinést mírné zatížení. Ve většině případů je tento dopad na výkon minimální a významně neovlivňuje celkový čas zpracování vašich úkolů souvisejících s prezentacemi.