---
title: Proteggi con password le presentazioni in Python
linktitle: Protezione con password
type: docs
weight: 20
url: /it/python-java/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- cifra PowerPoint
- decifra PowerPoint
- convalida la password della presentazione
- verifica la password della presentazione
- apri presentazione crittografata
- rimuovi la crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- Python
- Aspose.Slides
description: "Cifra, rileva, convalida, apri e decifra presentazioni PowerPoint PPT e PPTX protette da password con Aspose.Slides per Python via Java."
---
## **Panoramica**

Una password di apertura cifra una presentazione. È necessaria la password corretta per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita la modifica ma non cifra il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/python-java/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando il loro comportamento basato su file o su stream è importante.

## **Cifra una presentazione con una password di apertura**

Utilizzare [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#encrypt) per assegnare una password di apertura. Quindi utilizzare [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per salvare la presentazione crittografata.

Il seguente esempio cifra una presentazione PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mantieni pubbliche le proprietà del documento**

Per impostazione predefinita, Aspose.Slides include le proprietà del documento nella crittografia della presentazione. Il metodo [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) controlla questo comportamento in modo indipendente dalla crittografia del contenuto delle diapositive. Passare `False` prima di chiamare [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#encrypt) quando un indice, una classificazione, una ricerca o un sistema di gestione dei documenti deve leggere i metadati senza la password di apertura.

Il seguente esempio crea una presentazione PPTX crittografata lasciando pubbliche le sue proprietà di documento integrate:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Passare `False` a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) non rende pubbliche le diapositive, i master, i layout, le forme, i media o altri contenuti della presentazione. Influisce solo sulle proprietà del documento. Per leggere tali proprietà senza caricare il contenuto crittografato, consultare [Manage Presentation Properties](/slides/it/python-java/presentation-properties/).

## **Carica una presentazione crittografata**

Impostare [LoadOptions.setPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setPassword) alla password di apertura e passare le opzioni a [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è assente o errata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Lavora con la presentazione decifrata.
    pass
finally:
    presentation.dispose()
```

## **Rimuovi la crittografia da una presentazione**

Caricare la presentazione con la sua password di apertura, chiamare [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#removeEncryption) e salvare il risultato. La presentazione salvata può quindi essere caricata senza password.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Convalida una password di apertura prima del caricamento**

Utilizzare [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) per ottenere [PresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/) senza creare un'istanza completa della presentazione. Verificare [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#isPasswordProtected) prima di richiedere o convalidare una password. Quando è presente la protezione, convalidare il valore fornito con [PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Flusso di lavoro tramite percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions.setPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setPassword) e quindi carica la presentazione completa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Flusso di lavoro tramite stream**

Il sovraccarico stream di [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) fornisce lo stesso flusso di lavoro. Reimpostare la posizione di uno stream ricercabile prima di caricare la presentazione completa dallo stream.

Il seguente esempio utilizza un file PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Valori restituiti da checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#checkPassword) restituisce `True` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `False` in ciascuno di questi casi:

- La password è errata.
- La presentazione non dispone di una password di apertura.
- La password fornita è `None` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispezionare [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#isEncrypted) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, utilizzare [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#isPasswordProtected) come mostrato sopra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Raccomandazioni sulla sicurezza**

{{% alert color="warning" title="Sicurezza" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti e non necessari, mantenere le password in memoria solo per il tempo necessario e riutilizzare un risultato di convalida riuscito quando si carica immediatamente la presentazione.

Le proprietà pubbliche del documento possono rivelare nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati anche se il contenuto della presentazione è crittografato. Crittografare i metadati sensibili insieme alla presentazione. Lasciare le proprietà pubbliche dovrebbe essere una decisione esplicita presa solo quando i sistemi devono indicizzare, classificare, cercare o gestire il file senza una password di apertura.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Aprire l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Selezionare o caricare la presentazione.
1. Inserire una password per la protezione della visualizzazione.
1. Facoltativamente inserire una password separata per la protezione della modifica.
1. Applicare la protezione e scaricare il file risultante.

{{% alert color="info" title="Vedi anche" %}}
- [Write-Protect Presentations](/slides/it/python-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/it/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura cifra la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita la modifica senza cifrare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottenere le informazioni della presentazione, verificare se è presente la protezione con password di apertura e convalidare la password prima di creare un'istanza completa della presentazione.

**Un'applicazione può leggere i metadati senza la password di apertura?**

Sì, ma solo quando la presentazione è stata cifrata con la crittografia delle proprietà del documento disabilitata. L'applicazione deve quindi utilizzare la modalità di caricamento solo per le proprietà del documento descritta in [Manage Presentation Properties](/slides/it/python-java/presentation-properties/).

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.