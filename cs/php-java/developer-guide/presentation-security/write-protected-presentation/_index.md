---
title: Zabezpečení prezentací proti zápisu v PHP
linktitle: Ochrana proti zápisu
type: docs
weight: 25
url: /cs/php-java/write-protected-presentation/
keywords:
- ochrana proti zápisu
- ochrana proti zápisu PowerPoint
- heslo pro úpravy
- omezit úpravy prezentace
- odstranit ochranu proti zápisu
- ověřit heslo pro úpravy
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Nastavte, detekujte, ověřujte a odstraňujte hesla pro ochranu proti zápisu v prezentacích PowerPoint PPT a PPTX pomocí Aspose.Slides pro PHP."
---
## **Úvod**

Heslo pro ochranu proti zápisu omezuje úpravy prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou proti zápisu bez hesla. V závislosti na aplikaci mohou také upravovat obsah a uložit jej pod jiným názvem, takže ochrana proti zápisu by neměla být považována za mechanismus zachování důvěrnosti.

Otevírací heslo má jiný účel: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Pro šifrování prezentace nebo ověření otevíracího hesla viz [Ochrana prezentací heslem](/slides/cs/php-java/password-protected-presentation/).

Postupy v tomto článku se vztahují na prezentace PPT i PPTX. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát uložení PPT.

## **Nastavení ochrany proti zápisu na prezentaci**

Použijte [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#setWriteProtection) k přiřazení hesla pro úpravu prezentace. Uložení prezentace zachová nastavení ochrany.

Následující příklad nastavuje ochranu proti zápisu na PPTX prezentaci:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Načtení prezentace chráněné proti zápisu**

Protože ochrana proti zápisu nešifruje obsah prezentace, není při načítání prezentace vyžadováno žádné heslo. Heslo je relevantní pouze při ověřování oprávnění k úpravě chráněné prezentace.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Nevkládejte heslo pro ochranu proti zápisu do [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword). Tato metoda přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, poskytněte otevírací heslo pro její načtení a heslo pro ochranu proti zápisu zpracujte samostatně.

## **Odebrání ochrany proti zápisu z prezentace**

Použijte [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#removeWriteProtection) k odebrání omezení úprav a poté prezentaci uložte.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Pro prohlédnutí souboru bez vytvoření úplné instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) zavolejte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) a podívejte se na [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#isWriteProtected). Metoda používá [NullableBool](https://reference.aspose.com/slides/cs/php-java/aspose.slides/nullablebool/) a vrací `NullableBool::True`, když je detekována ochrana proti zápisu.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

Přetížení metody pro stream v [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/#getPresentationInfo) poskytuje stejnou informaci pro prezentaci dodanou jako stream.

## **Ověření hesla pro ochranu proti zápisu**

Použijte [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#checkWriteProtection) k ověření hesla pro úpravy bez načtení celé prezentace. Nejprve zkontrolujte [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#isWriteProtected), aby aplikace požadovala nebo ověřovala heslo jen v případě, že je přítomna ochrana proti zápisu.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#checkWriteProtection) ověřuje pouze heslo pro ochranu proti zápisu. Neověřuje otevírací heslo ani nesoustředí se na to, zda může být načten šifrovaný obsah. Obráceně, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#checkPassword) ověřuje pouze otevírací heslo. Pokud je již načtena úplná prezentace, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#checkWriteProtection) poskytuje ekvivalentní kontrolu ochrany proti zápisu prostřednictvím svého správce ochrany.

V produkčních aplikacích neukládejte hesla do protokolů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti pouze po nezbytně nutnou dobu.

{{% alert color="info" title="Viz také" %}}
- [Ochrana prezentací heslem](/slides/cs/php-java/password-protected-presentation/)
- [Prezentace jen pro čtení](/slides/cs/php-java/read-only-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Šifruje ochrana proti zápisu prezentaci?**

Ne. Omezuje úpravy, ale nechává obsah prezentace dostupný pro načtení a prohlížení.

**Je heslo pro ochranu proti zápisu vyžadováno pro otevření prezentace?**

Ne. Pro načtení šifrovaného obsahu prezentace je vyžadováno pouze otevírací heslo.

**Může mít prezentace současně otevírací heslo i heslo pro ochranu proti zápisu?**

Ano. Poskytněte otevírací heslo prostřednictvím možností načtení pro otevření šifrované prezentace a heslo pro ochranu proti zápisu ověřujte samostatně, pokud je potřeba oprávnění k úpravám.