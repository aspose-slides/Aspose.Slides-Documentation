---
title: Write-Protect Presentations in PHP
linktitle: Write Protection
type: docs
weight: 25
url: /php-java/write-protected-presentation/
keywords:
- write protection
- write-protect PowerPoint
- password to modify
- restrict presentation editing
- remove write protection
- validate modification password
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Set, detect, validate, and remove write-protection passwords in PowerPoint PPT and PPTX presentations using Aspose.Slides for PHP."
---

## **Introduction**

A write-protection password restricts modification of a presentation but does not encrypt its content. Users can load and view a write-protected presentation without the password. Depending on the application, they may also be able to edit the content and save it under a different name, so write protection should not be treated as a confidentiality mechanism.

An opening password serves a different purpose: it encrypts the presentation and is required to load its content. To encrypt a presentation or validate an opening password, see [Password-Protect Presentations](/slides/php-java/password-protected-presentation/).

The workflows in this article apply to both PPT and PPTX presentations. The examples use PPTX files; when saving to PPT, use the `.ppt` extension and the corresponding PPT save format.

## **Set Write Protection on a Presentation**

Use [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setWriteProtection) to assign a password for modifying a presentation. Saving the presentation persists the protection setting.

The following example sets write protection on a PPTX presentation:

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

## **Load a Write-Protected Presentation**

Because write protection does not encrypt presentation content, no password is required to load the presentation. The password is relevant only when validating authorization to modify the protected presentation.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Do not pass a write-protection password to [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword). That method accepts an opening password for encrypted content. If a presentation has both protection types, supply the opening password to load it and handle the write-protection password separately.

## **Remove Write Protection from a Presentation**

Use [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeWriteProtection) to remove the modification restriction, then save the presentation.

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

## **Check Whether a Presentation Is Write Protected**

To inspect a file without creating a complete [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance, call [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) and inspect [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isWriteProtected). The method uses [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) and returns `NullableBool::True` when write protection is detected.

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

The stream overload of [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) provides the same information for a presentation supplied as a stream.

## **Validate a Write-Protection Password**

Use [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#checkWriteProtection) to validate a modification password without loading the complete presentation. Check [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isWriteProtected) first so that the application requests or validates a password only when write protection is present.

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

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#checkWriteProtection) validates only the write-protection password. It does not validate an opening password or determine whether encrypted content can be loaded. Conversely, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#checkPassword) validates only an opening password. If a complete presentation has already been loaded, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#checkWriteProtection) provides the equivalent write-protection check through its protection manager.

In production applications, do not log passwords or include them in diagnostic messages. Avoid unnecessary repeated validation attempts, and retain passwords in memory only as long as needed.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Does write protection encrypt a presentation?**

No. It restricts modification but leaves the presentation content available for loading and viewing.

**Is the write-protection password required to open a presentation?**

No. Only an opening password is required to load encrypted presentation content.

**Can a presentation have both an opening password and a write-protection password?**

Yes. Supply the opening password through the load options to open the encrypted presentation, and validate the write-protection password separately when modification authorization is required.
