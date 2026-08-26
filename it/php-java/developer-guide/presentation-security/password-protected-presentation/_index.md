---
title: Presentazioni protette da password in PHP
linktitle: Protezione con password
type: docs
weight: 20
url: /it/php-java/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- crittografa PowerPoint
- decrittografa PowerPoint
- valida password della presentazione
- verifica password della presentazione
- apri presentazione crittografata
- rimuovi crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- PHP
- Aspose.Slides
description: "Crittografa, rileva, valida, apri e decrittografa presentazioni PowerPoint PPT e PPTX protette da password in PHP con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione offre riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita le modifiche ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/php-java/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando il loro comportamento basato su file o su stream è importante.

## **Crittografa una presentazione con una password di apertura**

Utilizzare [ProtectionManager::encrypt](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#encrypt) per assegnare una password di apertura. Quindi utilizzare [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) per salvare la presentazione crittografata.

Il seguente esempio crittografa una presentazione PPTX:

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

## **Caricare una presentazione crittografata**

Impostare [LoadOptions::setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword) sulla password di apertura e passare le opzioni a [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Lavora con la presentazione decrittografata.
} finally {
    $presentation->dispose();
}
```

## **Rimuovere la crittografia da una presentazione**

Caricare la presentazione con la sua password di apertura, chiamare [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeEncryption) e salvare il risultato. La presentazione salvata può quindi essere caricata senza password.

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

## **Validare una password di apertura prima del caricamento**

Utilizzare [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) per ottenere [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/) senza creare un'istanza completa della presentazione. Verificare [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#isPasswordProtected) prima di richiedere o convalidare una password. Quando è presente la protezione, convalidare il valore fornito con [PresentationInfo::checkPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Flusso di lavoro con percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions::setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword) e quindi carica la presentazione completa:

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

### **Flusso di lavoro con stream**

La versione stream di [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) fornisce lo stesso flusso di lavoro. Reimpostare la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

Il seguente esempio utilizza un file PPT:

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

### **Valori di ritorno di checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#checkPassword) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verificare se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispezionare [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isEncrypted) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, utilizzare [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#isPasswordProtected) come mostrato sopra.

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

## **Raccomandazioni di sicurezza**

{{% alert color="warning" title="Sicurezza" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti non necessari, mantenere le password in memoria solo per il tempo necessario e riutilizzare un risultato di convalida riuscito quando si carica immediatamente la presentazione.
{{% /alert %}}

## **Proteggere con password una presentazione online**

1. Aprire l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
2. Selezionare o caricare la presentazione.
3. Inserire una password per la protezione della visualizzazione.
4. Facoltativamente, inserire una password separata per la protezione della modifica.
5. Applicare la protezione e scaricare il file risultante.

{{% alert color="info" title="Vedi anche" %}}
- [Write-Protect Presentations](/slides/it/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/it/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricarne il contenuto. Una password di protezione in scrittura limita le modifiche senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottenere le informazioni della presentazione, verificare se è presente una protezione con password di apertura e convalidare la password prima di creare un'istanza completa della presentazione.

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.