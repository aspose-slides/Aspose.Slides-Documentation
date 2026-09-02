---
title: Ochrana prezentací heslem v PHP
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/php-java/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrování PowerPoint
- dešifrování PowerPoint
- ověření hesla prezentace
- kontrola hesla prezentace
- otevření zašifrované prezentace
- odstranění šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- PHP
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v PHP pomocí Aspose.Slides."
---
## **Přehled**

Otevírací heslo zašifruje prezentaci. Správné heslo je vyžadováno k načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro zápisovou ochranu. Zápisová ochrana omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/php-java/write-protected-presentation/).

Níže uvedené pracovní postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité jejich chování při práci se soubory i proudy.

## **Zašifrování prezentace otevíracím heslem**

Použijte [ProtectionManager::encrypt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#encrypt) k přiřazení otevíracího hesla. Poté použijte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) k uložení zašifrované prezentace.

Následující příklad zašifruje PPTX prezentaci:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Načtení zašifrované prezentace**

Nastavte [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword) na otevírací heslo a při načítání souboru předávejte možnosti do [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Načtení selže, pokud je vyžadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Pracujte s dešifrovanou prezentací.
} finally {
    $presentation->dispose();
}
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeEncryption) a výsledek uložte. Uloženou prezentaci lze poté načíst bez hesla.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ověření otevíracího hesla před načtením**

Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) k získání [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/) bez vytvoření úplné instance prezentace. Před požádáním o heslo nebo jeho ověřením zkontrolujte [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#isPasswordProtected). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [PresentationInfo::checkPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Pracovní postup s cestou k souboru**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu do [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword) a poté načte celou prezentaci:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Pracovní postup se streamem**

Přetížení proudem metody [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) poskytuje stejný pracovní postup. Před načtením celé prezentace z tohoto proudu resetujte pozici vyhledávatelného proudu.

Následující příklad používá soubor PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Návratové hodnoty metody checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#checkPassword) vrací `true` pouze pokud má prezentace otevírací heslo a zadané heslo je správné. V následujících případech vrací `false`:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Zkontrolovat, zda je načtená prezentace zašifrovaná**

Po načtení prezentace se správným heslem zkontrolujte [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isEncrypted), abyste potvrdili, že zdrojová prezentace byla zašifrována. Pro detekci ochrany otevíracím heslem před načtením použijte [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#isPasswordProtected) podle výše uvedeného.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Bezpečnostní doporučení**

{{% alert color="warning" title="Bezpečnost" %}}
Nezaznamenávejte otevírací hesla ani je neuvádějte v diagnostických zprávách. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti pouze po dobu, kdy jsou potřebná, a při okamžitém načítání prezentace znovu použijte úspěšný výsledek ověření.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu zobrazení.
1. Volitelně zadejte samostatné heslo pro ochranu úprav.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="Viz také" %}}
- [Write-Protect Presentations](/slides/cs/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro zápisovou ochranu?**

Otevírací heslo šifruje prezentaci a je vyžadováno k načtení jejího obsahu. Heslo pro zápisovou ochranu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo, aniž načtu všechny snímky?**

Ano. Získejte informace o prezentaci, zkontrolujte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením úplné instance prezentace.

**Podporují pracovní postupy pro kontrolu hesla jak PPT, tak PPTX?**

Ano. Detekce a ověření hesla podle cesty k souboru i proudu se chová stejným způsobem pro prezentace PPT i PPTX.