---
title: Proteggi le presentazioni con password in Python
linktitle: Protezione password
type: docs
weight: 20
url: /it/python-net/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- cifratura PowerPoint
- decifratura PowerPoint
- convalida password della presentazione
- verifica password della presentazione
- apri presentazione crittografata
- rimuovi crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- Python
- Aspose.Slides
description: "Cifra, rileva, valida, apri e decifra presentazioni PowerPoint PPT e PPTX protette da password in Python con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita le modifiche ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/python-net/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati dove il comportamento basato su file e su stream è importante.

## **Crittografa una presentazione con una password di apertura**

Utilizza [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/encrypt/) per assegnare una password di apertura. Quindi utilizza [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per salvare la presentazione crittografata.

L'esempio seguente crittografa una presentazione PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Mantieni le proprietà del documento pubbliche**

Per impostazione predefinita, Aspose.Slides include le proprietà del documento nella crittografia della presentazione. La proprietà [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) controlla questo comportamento in modo indipendente dalla crittografia del contenuto delle diapositive. Impostala su `False` prima di chiamare [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/encrypt/) quando un sistema di indicizzazione, classificazione, ricerca o gestione dei documenti deve leggere i metadati senza la password di apertura.

Il seguente esempio crea una presentazione PPTX crittografata lasciando pubbliche le sue proprietà del documento incorporate:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Impostare `encrypt_document_properties` su `False` non rende pubbliche le diapositive, i master, i layout, le forme, i media o altro contenuto della presentazione. Influisce solo sulle proprietà del documento. Per leggere queste proprietà senza caricare il contenuto crittografato, vedere [Manage Presentation Properties](/slides/it/python-net/presentation-properties/).

## **Carica una presentazione crittografata**

Imposta [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/) alla password di apertura e passa le opzioni a [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Lavora con la presentazione decrittata.
    pass
```

## **Rimuovi la crittografia da una presentazione**

Carica la presentazione con la sua password di apertura, chiama [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/remove_encryption/) e salva il risultato. La presentazione salvata può quindi essere caricata senza password.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Convalida una password di apertura prima del caricamento**

Utilizza [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) per ottenere [PresentationInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/) senza creare un'istanza completa della presentazione. Controlla [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/is_password_protected/) prima di richiedere o convalidare una password. Quando è presente una protezione, convalida il valore fornito con [PresentationInfo.check_password](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/check_password/).

### **Flusso di lavoro con percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/), quindi carica la presentazione completa:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Flusso di lavoro con stream**

La versione overload su stream di [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) fornisce lo stesso flusso di lavoro. Reimposta la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

Il seguente esempio utilizza un file PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Valori di ritorno di CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/check_password/) restituisce `True` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `False` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `None` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispeziona [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/is_encrypted/) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, usa `PresentationInfo.is_password_protected` come mostrato sopra.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Raccomandazioni di sicurezza**

{{% alert color="warning" title="Security" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evita tentativi di convalida ripetuti inutili, mantieni le password in memoria solo per il tempo necessario e riutilizza un risultato di convalida riuscito quando si carica immediatamente la presentazione.

Le proprietà pubbliche del documento possono rivelare i nomi degli autori, i titoli, gli oggetti, le parole chiave, le informazioni aziendali, i commenti e i valori personalizzati anche se il contenuto della presentazione è crittografato. Crittografa i metadati sensibili insieme alla presentazione. Lasciare le proprietà pubbliche dovrebbe essere una decisione esplicita presa solo quando i sistemi devono indicizzare, classificare, cercare o gestire il file senza una password di apertura.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Seleziona o carica la presentazione.
1. Inserisci una password per proteggere la visualizzazione.
1. Facoltativamente inserisci una password separata per la protezione della modifica.
1. Applica la protezione e scarica il file risultato.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/it/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/it/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita la modifica senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni sulla presentazione, verifica se è presente la protezione con password di apertura e convalida la password prima di creare un'istanza completa della presentazione.

**Un'applicazione può leggere i metadati senza la password di apertura?**

Sì, ma solo quando la presentazione è stata crittografata con `encrypt_document_properties` impostato su `False`. L'applicazione deve quindi utilizzare la modalità di caricamento solo delle proprietà del documento descritta in [Manage Presentation Properties](/slides/it/python-net/presentation-properties/).

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.