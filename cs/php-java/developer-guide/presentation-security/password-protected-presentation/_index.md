---
title: Ochrana prezentací heslem v PHP
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/php-java/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrování PowerPointu
- dešifrování PowerPointu
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
description: "Šifrujte, detekujte, ověřujte, otvírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v PHP pomocí Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/php-java/write-protected-presentation/).

Níže uvedené postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité jejich chování založené na souborech i na streamu.

## **Zašifrovat prezentaci pomocí otevíracího hesla**

Použijte [ProtectionManager::encrypt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#encrypt) k přiřazení otevíracího hesla. Poté použijte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) k uložení zašifrované prezentace.

Následující příklad zašifruje prezentaci PPTX:

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

## **Ponechat dokumentové vlastnosti veřejné**

Ve výchozím nastavení Aspose.Slides zahrnuje dokumentové vlastnosti do šifrování prezentace. Metoda [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) řídí toto chování nezávisle na šifrování obsahu snímků. Před voláním [ProtectionManager::encrypt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#encrypt) předávejte hodnotu `false`, pokud musí systém pro indexování, klasifikaci, vyhledávání nebo správu dokumentů číst metadata bez otevíracího hesla.

Následující příklad vytvoří zašifrovanou prezentaci PPTX a zároveň ponechá její vestavěné dokumentové vlastnosti veřejné:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Předání hodnoty `false` metodě [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) nezpřístupní snímky, hlavní snímky, rozvržení, tvary, média ani jiný obsah prezentace. Ovlivňuje pouze dokumentové vlastnosti. Pro čtení těchto vlastností bez načítání zašifrovaného obsahu viz [Manage Presentation Properties](/slides/cs/php-java/presentation-properties/).

## **Načíst zašifrovanou prezentaci**

Nastavte [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword) na otevírací heslo a předávejte možnosti do [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) při načítání souboru. Načítání selže, pokud je vyžadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

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

## **Odstranit šifrování z prezentace**

Nahrajte prezentaci s jejím otevíracím heslem, zavolejte [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeEncryption) a uložte výsledek. Uloženou prezentaci lze poté načíst bez hesla.

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

## **Ověřit otevírací heslo před načtením**

Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) k získání [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/) bez vytvoření úplné instance prezentace. Zkontrolujte [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#isPasswordProtected) před požádáním o heslo nebo jeho ověřením. Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [PresentationInfo::checkPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Workflow s cestou k souboru**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu metodě [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword) a poté načte úplnou prezentaci:

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

### **Workflow se streamem**

Přetížení streamu metody [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) poskytuje stejný postup. Před načtením úplné prezentace z tohoto streamu resetujte pozici vyhledávatelného streamu.

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

### **Návratové hodnoty checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#checkPassword) vrací `true` pouze když má prezentace otevírací heslo a zadané heslo je správné. Vrací `false` v každém z následujících případů:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `null` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Zkontrolovat, zda je načtená prezentace zašifrována**

Po načtení prezentace se správným heslem zkontrolujte [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isEncrypted), abyste potvrdili, že zdrojová prezentace byla zašifrována. Pro detekci ochrany otevíracím heslem před načtením použijte [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#isPasswordProtected) jak je uvedeno výše.

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

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Security" %}}
Nezaznamenávejte otevírací hesla ani je neuvádějte v diagnostických zprávách. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po nezbytně nutnou dobu a při okamžitém načítání prezentace opakovaně využívejte výsledek úspěšného ověření.

Veřejné dokumentové vlastnosti mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o firmě, komentáře a vlastní hodnoty, i když je obsah prezentace šifrovaný. Šifrujte citlivá metadata spolu s prezentací. Nechávat vlastnosti veřejné by mělo být explicitním rozhodnutím učiněným pouze tehdy, když systémy musí indexovat, klasifikovat, vyhledávat nebo spravovat soubor bez otevíracího hesla.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu zobrazení.
1. Volitelně zadejte samostatné heslo pro ochranu úprav.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/cs/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením úplné instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale pouze tehdy, když byla prezentace šifrována s vypnutým šifrováním dokumentových vlastností. Aplikace pak musí použít režim načítání pouze dokumentových vlastností popsaný v [Manage Presentation Properties](/slides/cs/php-java/presentation-properties/).

**Podporují pracovní postupy ověřování hesla jak PPT, tak PPTX?**

Ano. Detekce a ověřování hesel založené na cestě k souboru i na streamu se chovají stejně pro prezentace PPT i PPTX.