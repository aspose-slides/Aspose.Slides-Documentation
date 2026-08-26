---
title: Presentazioni con protezione dalla scrittura in PHP
linktitle: Protezione dalla scrittura
type: docs
weight: 25
url: /it/php-java/write-protected-presentation/
keywords:
- protezione dalla scrittura
- protezione dalla scrittura PowerPoint
- password per modificare
- limitare la modifica della presentazione
- rimuovere la protezione dalla scrittura
- convalidare la password di modifica
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione dalla scrittura nelle presentazioni PowerPoint PPT e PPTX utilizzando Aspose.Slides per PHP."
---
## **Introduzione**

Una password di protezione dalla scrittura limita la modifica di una presentazione ma non cifra il suo contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta dalla scrittura senza la password. A seconda dell’applicazione, potrebbero anche essere in grado di modificare il contenuto e salvarlo con un nome diverso, quindi la protezione dalla scrittura non deve essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: cifra la presentazione ed è necessaria per caricarne il contenuto. Per cifrare una presentazione o convalidare una password di apertura, vedere [Proteggi le presentazioni con password](/slides/it/php-java/password-protected-presentation/).

I flussi di lavoro in questo articolo si applicano sia a presentazioni PPT sia a PPTX. Gli esempi usano file PPTX; quando si salva in PPT, utilizzare l’estensione `.ppt` e il formato di salvataggio PPT corrispondente.

## **Imposta la protezione dalla scrittura su una presentazione**

Utilizzare [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#setWriteProtection) per assegnare una password per la modifica di una presentazione. Il salvataggio della presentazione persiste l’impostazione di protezione.

Il seguente esempio imposta la protezione dalla scrittura su una presentazione PPTX:

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

## **Carica una presentazione protetta dalla scrittura**

Poiché la protezione dalla scrittura non cifra il contenuto della presentazione, non è richiesta alcuna password per caricare la presentazione. La password è rilevante solo quando si convalida l’autorizzazione a modificare la presentazione protetta.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Non passare una password di protezione dalla scrittura a [LoadOptions::setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword). Quel metodo accetta una password di apertura per contenuti cifrati. Se una presentazione ha entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione dalla scrittura.

## **Rimuovi la protezione dalla scrittura da una presentazione**

Utilizzare [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeWriteProtection) per rimuovere la restrizione di modifica, quindi salvare la presentazione.

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

## **Verifica se una presentazione è protetta dalla scrittura**

Per ispezionare un file senza creare un’istanza completa di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), chiamare [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) e controllare [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#isWriteProtected). Il metodo utilizza [NullableBool](https://reference.aspose.com/slides/it/php-java/aspose.slides/nullablebool/) e restituisce `NullableBool::True` quando viene rilevata la protezione dalla scrittura.

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

La sovraccarico di flusso di [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) fornisce le stesse informazioni per una presentazione fornita come stream.

## **Convalida una password di protezione dalla scrittura**

Utilizzare [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#checkWriteProtection) per convalidare una password di modifica senza caricare l’intera presentazione. Controllare prima [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#isWriteProtected) in modo che l’applicazione richieda o convalidi una password solo quando è presente la protezione dalla scrittura.

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

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#checkWriteProtection) convalida solo la password di protezione dalla scrittura. Non convalida una password di apertura né determina se i contenuti cifrati possono essere caricati. Al contrario, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#checkPassword) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#checkWriteProtection) fornisce il controllo equivalente di protezione dalla scrittura tramite il suo gestore di protezione.

Nelle applicazioni di produzione, non registrare le password né includerle in messaggi diagnostici. Evitare tentativi di convalida ripetuti non necessari e mantenere le password in memoria solo per il tempo strettamente necessario.

{{% alert color="info" title="Vedi anche" %}}
- [Presentazioni protette da password](/slides/it/php-java/password-protected-presentation/)
- [Presentazioni di sola lettura](/slides/it/php-java/read-only-presentation/)
- [Firma digitale in PowerPoint](/slides/it/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione dalla scrittura cifra una presentazione?**

No. Limita la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**La password di protezione dalla scrittura è necessaria per aprire una presentazione?**

No. Solo una password di apertura è necessaria per caricare il contenuto cifrato di una presentazione.

**Una presentazione può avere sia una password di apertura sia una password di protezione dalla scrittura?**

Sì. Fornire la password di apertura tramite le opzioni di caricamento per aprire la presentazione cifrata e convalidare separatamente la password di protezione dalla scrittura quando è richiesta l’autorizzazione alla modifica.