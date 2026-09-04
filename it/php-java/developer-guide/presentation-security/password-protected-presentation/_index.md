---
title: Proteggi con password le presentazioni in PHP
linktitle: Protezione con password
type: docs
weight: 20
url: /it/php-java/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- criptare PowerPoint
- decriptare PowerPoint
- convalidare la password della presentazione
- verificare la password della presentazione
- aprire una presentazione criptata
- rimuovere la crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- PHP
- Aspose.Slides
description: "Cifra, rileva, convalida, apri e decripta presentazioni PowerPoint PPT e PPTX protette da password in PHP con Aspose.Slides."
---
## **Panoramica**

Una password di apertura cripta una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita la modifica ma non cripta il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Proteggi le presentazioni in scrittura](/slides/it/php-java/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia a presentazioni PPT sia PPTX. Gli esempi usano entrambi i formati quando il comportamento basato su file e su stream è importante.

## **Cripta una presentazione con una password di apertura**

Usa [ProtectionManager::encrypt](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#encrypt) per assegnare una password di apertura. Quindi usa [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) per salvare la presentazione crittografata.

Il seguente esempio cripta una presentazione PPTX:

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

## **Mantieni le proprietà del documento pubbliche**

Per impostazione predefinita, Aspose.Slides include le proprietà del documento nella crittografia della presentazione. Il metodo [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) controlla questo comportamento in modo indipendente dalla crittografia del contenuto delle diapositive. Passa `false` prima di chiamare [ProtectionManager::encrypt](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#encrypt) quando un sistema di indicizzazione, classificazione, ricerca o gestione documentale deve leggere i metadati senza la password di apertura.

Il seguente esempio crea una presentazione PPTX crittografata lasciando pubbliche le sue proprietà di documento incorporate:

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

Passare `false` a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) non rende pubblici diapositive, master, layout, forme, media o altro contenuto della presentazione. Influisce solo sulle proprietà del documento. Per leggere tali proprietà senza caricare il contenuto crittografato, vedere [Gestisci le proprietà della presentazione](/slides/it/php-java/presentation-properties/).

## **Carica una presentazione crittografata**

Imposta [LoadOptions::setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword) alla password di apertura e passa le opzioni a [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Lavora con la presentazione decrittata.
} finally {
    $presentation->dispose();
}
```

## **Rimuovi la crittografia da una presentazione**

Carica la presentazione con la sua password di apertura, chiama [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeEncryption) e salva il risultato. La presentazione salvata può quindi essere caricata senza password.

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

## **Convalida una password di apertura prima del caricamento**

Usa [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) per ottenere [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/) senza creare un'istanza completa della presentazione. Controlla [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#isPasswordProtected) prima di richiedere o convalidare una password. Quando è presente una protezione, convalida il valore fornito con [PresentationInfo::checkPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#checkPassword).

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

Il sovraccarico stream di [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) fornisce lo stesso flusso di lavoro. Reimposta la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

Il seguente esempio usa un file PPT:

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

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispeziona [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isEncrypted) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione da password di apertura prima del caricamento, usa [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#isPasswordProtected) come mostrato sopra.

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
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evita tentativi di convalida ripetuti non necessari, mantieni le password in memoria solo per il tempo necessario e riutilizza un risultato di convalida riuscito quando si carica immediatamente la presentazione.

Le proprietà del documento pubbliche possono rivelare nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati anche se il contenuto della presentazione è crittografato. Cripta i metadati sensibili insieme alla presentazione. Lasciare le proprietà pubbliche dovrebbe essere una decisione esplicita presa solo quando i sistemi devono indicizzare, classificare, cercare o gestire il file senza una password di apertura.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Seleziona o carica la presentazione.
1. Inserisci una password per la protezione di visualizzazione.
1. Facoltativamente inserisci una password diversa per la protezione di modifica.
1. Applica la protezione e scarica il file risultante.

{{% alert color="info" title="Vedi anche" %}}
- [Proteggi le presentazioni in scrittura](/slides/it/php-java/write-protected-presentation/)
- [Firma digitale in PowerPoint](/slides/it/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura cripta la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita la modifica senza criptare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni della presentazione, verifica se è presente una protezione da password di apertura e convalida la password prima di creare un'istanza completa della presentazione.

**Un'applicazione può leggere i metadati senza la password di apertura?**

Sì, ma solo quando la presentazione è stata crittografata con la crittografia delle proprietà del documento disabilitata. L'applicazione deve quindi utilizzare la modalità di caricamento solo per le proprietà del documento descritta in [Gestisci le proprietà della presentazione](/slides/it/php-java/presentation-properties/).

**I flussi di lavoro per il controllo delle password supportano sia PPT sia PPTX?**

Sì. Il rilevamento e la convalida delle password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.