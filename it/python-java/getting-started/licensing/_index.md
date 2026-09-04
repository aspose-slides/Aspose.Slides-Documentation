---
title: Licenza
type: docs
weight: 80
url: /it/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- file di licenza
- licenza temporanea
- licenza a consumo
- limitazioni di valutazione
description: "Applica una licenza da file, basata su byte o a consumo in Aspose.Slides per Python via Java e rimuovi le limitazioni di valutazione dalle tue applicazioni."
---
## **Panoramica**

Aspose.Slides for Python via Java può essere eseguito in modalità di valutazione o con una licenza. Questo articolo spiega come applicare una licenza da un file o da byte e come configurare la licenza a consumo.

Per le opzioni di acquisto, vedere [Pricing Information](https://purchase.aspose.com/pricing/slides/it/family). Per domande generali su licenze e acquisti, vedere [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

Per le limitazioni della valutazione e come richiedere una licenza temporanea, vedere [Evaluate Aspose.Slides](/slides/it/python-java/evaluate-aspose-slides/). Applicare una licenza temporanea nello stesso modo di un file di licenza acquistato.

## **Informazioni sulla Licenza**

Un file di licenza contiene informazioni come il nome del prodotto, il numero di sviluppatori con licenza e la data di scadenza dell'abbonamento. Il file è un XML firmato digitalmente.

{{% alert color="warning" title="Warning" %}}
Non modificare il file di licenza. Anche un ritorno a capo extra può invalidare la sua firma digitale.
{{% /alert %}}

Applicare la licenza una volta per applicazione o processo, prima di creare presentazioni o eseguire altre operazioni di Aspose.Slides. Per un file di licenza, utilizzare la classe [License](https://reference.aspose.com/slides/it/python-java/aspose.slides/license/). La licenza a consumo utilizza una coppia di chiavi pubblica e privata invece di un file di licenza.

## **Applicare una Licenza**

Gli esempi seguenti presumono che Aspose.Slides for Python via Java e i relativi prerequisiti siano installati. Ogni esempio è uno script autonomo che avvia la JVM, importa l'API e applica una licenza. Nella tua applicazione, esegui le operazioni di presentazione dopo aver applicato la licenza e chiudi la JVM solo dopo che tutto il lavoro di Aspose.Slides è completato.

### **Applicare una Licenza da un File**

Passare il percorso del file di licenza a [License.setLicense](https://reference.aspose.com/slides/it/python-java/aspose.slides/license/#setLicense). Sostituire `Aspose.Slides.lic` con il percorso del proprio file di licenza.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Eseguire le operazioni di presentazione qui, prima di chiudere la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Utilizzare il nome file esatto, includendo l'estensione. Ad esempio, se il file si chiama `Aspose.Slides.lic.xml`, includere `.xml` nel percorso. Un percorso assoluto evita ambiguità sulla directory di lavoro dell'applicazione.

L'esempio utilizza [License.isLicensed](https://reference.aspose.com/slides/it/python-java/aspose.slides/license/#isLicensed) per verificare se la licenza è stata applicata.

### **Applicare una Licenza da Byte**

Utilizzare [License.setLicenseFromBytes](https://reference.aspose.com/slides/it/python-java/aspose.slides/license/#setLicenseFromBytes) quando la licenza è disponibile come byte Python. L'esempio seguente legge il file in modalità binaria e lo chiude prima di applicare la licenza.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Eseguire le operazioni di presentazione qui, prima di chiudere la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Mantenere i byte originali invariati. Non decodificare, riformattare o modificare in altro modo il contenuto della licenza prima di applicarla.

## **Applicare una Licenza a Consumo**

La licenza a consumo ti addebita in base all'uso dell'API. Dopo aver ottenuto una licenza a consumo, applica le sue chiavi pubblica e privata con [Metered.setMeteredKey](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/#setMeteredKey). Inizializza l'oggetto [Metered](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/) e applica le chiavi una volta all'avvio dell'applicazione.

L'esempio seguente legge le chiavi dalle variabili d'ambiente `ASPOSE_METERED_PUBLIC_KEY` e `ASPOSE_METERED_PRIVATE_KEY`. Impostare entrambe le variabili prima di eseguire lo script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Eseguire le operazioni di presentazione qui, prima di chiudere la JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
La licenza a consumo richiede una connessione Internet per convalidare le chiavi e segnalare l'utilizzo. Tenere la chiave privata fuori dal codice sorgente e dai log. Consultare le [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) per dettagli su connettività e fatturazione.
{{% /alert %}}

## **FAQ**

**Devo installare un pacchetto diverso dopo aver acquistato una licenza?**

No. Applicare la licenza allo stesso pacchetto usato per la valutazione.

**Devo applicare una licenza per ogni presentazione?**

No. Applicarla una volta all'avvio dell'applicazione, prima di creare o caricare presentazioni.

**Posso rinominare il file di licenza?**

Sì. Utilizzare il nuovo nome file esatto nel codice e mantenere invariato il contenuto del file.

**Posso usare una licenza temporanea con l'esempio basato su byte?**

Sì. Leggere il file di licenza temporaneo come byte e applicarlo nello stesso modo di una licenza acquistata.