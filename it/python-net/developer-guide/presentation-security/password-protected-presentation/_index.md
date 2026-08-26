---
title: Proteggi le presentazioni con password in Python
linktitle: Protezione con password
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
description: "Cifra, rileva, convalida, apri e decifra presentazioni PowerPoint PPT e PPTX protette da password in Python con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa dalla password di protezione in scrittura. La protezione in scrittura limita la modifica ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/python-net/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT sia a PPTX. Gli esempi utilizzano entrambi i formati dove il comportamento basato su file e su stream è importante.

## **Crittografa una presentazione con una password di apertura**

Utilizzare [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/encrypt/) per assegnare una password di apertura. Quindi utilizzare [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per salvare la presentazione crittografata.

Il seguente esempio crittografa una presentazione PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Carica una presentazione crittografata**

Impostare [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/) sulla password di apertura e passare le opzioni a [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Lavora con la presentazione decrittata.
    pass
```

## **Rimuovi la crittografia da una presentazione**

Caricare la presentazione con la sua password di apertura, chiamare [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/remove_encryption/), e salvare il risultato. La presentazione salvata può quindi essere caricata senza password.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Convalida una password di apertura prima del caricamento**

Utilizzare [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) per ottenere [PresentationInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/) senza creare un'istanza completa della presentazione. Controllare [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/is_password_protected/) prima di richiedere o convalidare una password. Quando è presente una protezione, convalidare il valore fornito con [PresentationInfo.check_password](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/check_password/).

### **Flusso di lavoro con percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/), e quindi carica la presentazione completa:

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

L'overload basato su stream di [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) fornisce lo stesso flusso di lavoro. Reimpostare la posizione di un flusso ricercabile prima di caricare la presentazione completa da quel flusso.

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

Dopo aver caricato una presentazione con la password corretta, esaminare [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/is_encrypted/) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, utilizzare `PresentationInfo.is_password_protected` come mostrato sopra.

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
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti e non necessari, conservare le password in memoria solo per il tempo strettamente necessario e riutilizzare un risultato di convalida riuscito quando si carica immediatamente la presentazione.
{{% /alert %}}

## **Proteggi una presentazione con password online**

1. Aprire l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Selezionare o caricare la presentazione.
1. Inserire una password per la protezione della visualizzazione.
1. Facoltativamente inserire una password separata per la protezione della modifica.
1. Applicare la protezione e scaricare il file risultante.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/it/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/it/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricarne il contenuto. Una password di protezione in scrittura limita la modifica senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottenere le informazioni della presentazione, verificare se è presente una protezione con password di apertura e convalidare la password prima di creare un'istanza completa della presentazione.

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.