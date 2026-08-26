---
title: Zabezpieczanie prezentacji przed zapisem w PHP
linktitle: Ochrona przed zapisem
type: docs
weight: 25
url: /pl/php-java/write-protected-presentation/
keywords:
- ochrona przed zapisem
- zabezpieczenie PowerPoint przed zapisem
- hasło do modyfikacji
- ograniczenie edycji prezentacji
- usunięcie ochrony przed zapisem
- weryfikacja hasła modyfikacji
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Ustawianie, wykrywanie, weryfikacja i usuwanie haseł ochrony przed zapisem w prezentacjach PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla PHP."
---
## **Wprowadzenie**

Hasło ochrony przed zapisem ogranicza modyfikację prezentacji, ale nie szyfruje jej treści. Użytkownicy mogą wczytać i przeglądać prezentację zabezpieczoną przed zapisem bez hasła. W zależności od aplikacji mogą również edytować treść i zapisać ją pod inną nazwą, więc ochrona przed zapisem nie powinna być traktowana jako mechanizm poufności.

Hasło otwierające służy innemu celowi: szyfruje prezentację i jest wymagane do wczytania jej treści. Aby zaszyfrować prezentację lub zweryfikować hasło otwierające, zobacz [Password-Protect Presentations](/slides/pl/php-java/password-protected-presentation/).

Procedury opisane w tym artykule odnoszą się zarówno do prezentacji PPT, jak i PPTX. Przykłady używają plików PPTX; przy zapisywaniu do PPT użyj rozszerzenia `.ppt` oraz odpowiedniego formatu zapisu PPT.

## **Ustaw ochronę przed zapisem w prezentacji**

Użyj [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#setWriteProtection), aby przypisać hasło do modyfikacji prezentacji. Zapisanie prezentacji zachowuje ustawienie ochrony.

Poniższy przykład ustawia ochronę przed zapisem w prezentacji PPTX:

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

## **Wczytaj prezentację zabezpieczoną przed zapisem**

Ponieważ ochrona przed zapisem nie szyfruje treści prezentacji, do wczytania prezentacji nie jest wymagane żadne hasło. Hasło jest istotne jedynie przy weryfikacji uprawnień do modyfikacji zabezpieczonej prezentacji.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Nie przekazuj hasła ochrony przed zapisem do [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword). Ta metoda przyjmuje hasło otwierające do zaszyfrowanej treści. Jeśli prezentacja ma oba typy ochrony, podaj hasło otwierające, aby ją wczytać, i obsłuż osobno hasło ochrony przed zapisem.

## **Usuń ochronę przed zapisem z prezentacji**

Użyj [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#removeWriteProtection), aby usunąć ograniczenie modyfikacji, a następnie zapisz prezentację.

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

## **Sprawdź, czy prezentacja jest zabezpieczona przed zapisem**

Aby sprawdzić plik bez tworzenia pełnego obiektu [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), wywołaj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) i przejrzyj [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#isWriteProtected). Metoda używa [NullableBool](https://reference.aspose.com/slides/pl/php-java/aspose.slides/nullablebool/) i zwraca `NullableBool::True`, gdy wykryto ochronę przed zapisem.

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

Przeciążenie strumieniowe [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) dostarcza te same informacje dla prezentacji podanej jako strumień.

## **Sprawdź hasło ochrony przed zapisem**

Użyj [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#checkWriteProtection), aby zweryfikować hasło modyfikacji bez wczytywania pełnej prezentacji. Najpierw sprawdź [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#isWriteProtected), aby aplikacja żądała lub weryfikowała hasło tylko wtedy, gdy istnieje ochrona przed zapisem.

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

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#checkWriteProtection) weryfikuje wyłącznie hasło ochrony przed zapisem. Nie weryfikuje hasła otwierającego ani nie określa, czy zaszyfrowaną treść można wczytać. Natomiast [PresentationInfo::checkPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#checkPassword) weryfikuje wyłącznie hasło otwierające. Jeśli pełna prezentacja została już wczytana, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#checkWriteProtection) zapewnia równoważny test ochrony przed zapisem poprzez swój menedżer ochrony.

W aplikacjach produkcyjnych nie loguj haseł ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych, powtarzających się prób weryfikacji i przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne.

{{% alert color="info" title="Zobacz także" %}}
- [Password-Protect Presentations](/slides/pl/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/pl/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Czy ochrona przed zapisem szyfruje prezentację?**

Nie. Ogranicza modyfikację, ale pozostawia treść prezentacji dostępną do wczytania i przeglądania.

**Czy hasło ochrony przed zapisem jest wymagane do otwarcia prezentacji?**

Nie. Jedynie hasło otwierające jest wymagane do wczytania zaszyfrowanej treści prezentacji.

**Czy prezentacja może mieć zarówno hasło otwierające, jak i hasło ochrony przed zapisem?**

Tak. Podaj hasło otwierające w opcjach wczytywania, aby otworzyć zaszyfrowaną prezentację, i osobno zweryfikuj hasło ochrony przed zapisem, gdy wymagana jest autoryzacja do modyfikacji.