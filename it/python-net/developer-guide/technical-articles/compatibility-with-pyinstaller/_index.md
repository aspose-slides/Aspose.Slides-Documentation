---
title: Compatibilità con PyInstaller e cx_Freeze
linktitle: Compatibilità con PyInstaller
type: docs
weight: 122
url: /it/python-net/compatibility-with-pyinstaller/
keywords:
- compatibilità
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Imballa Aspose.Slides per Python via .NET con PyInstaller. Segui questa guida per raggruppare, configurare e risolvere i problemi della tua app in un eseguibile autonomo."
---
## **Introduzione**

Le estensioni Aspose.Slides per Python via .NET sono estensioni C standard per Python, quindi possono essere congelate come dipendenze del programma con strumenti come PyInstaller e cx_Freeze (o simili). Questo consente di creare file eseguibili dai propri script Python. Tali strumenti sono chiamati “freezer” perché raggruppano il tuo codice e le sue dipendenze in un unico file distribuibile che può essere eseguito su altre macchine senza richiedere un'installazione di Python o librerie aggiuntive. Questo approccio semplifica la distribuzione delle tue applicazioni Python.

Il congelamento di un’estensione Aspose.Slides per Python via .NET come dipendenza è illustrato di seguito con un semplice programma che utilizza Aspose.Slides.

## **PyInstaller**

In generale, non è necessario nulla di speciale quando si impacchetta un programma che dipende da un’estensione Aspose.Slides per Python via .NET. Quando un programma importa l’estensione in modo visibile a PyInstaller, l’estensione verrà inclusa nel programma. Poiché Aspose.Slides per Python via .NET include hook per PyInstaller, le sue dipendenze sono rilevate automaticamente e copiate nel bundle.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Tuttavia, PyInstaller può occasionalmente non rilevare importazioni nascoste—moduli importati dinamicamente o indirettamente dal tuo codice. Per includere un’importazione nascosta, usa le opzioni di PyInstaller. Le dipendenze dell’estensione sono specificate negli hook di PyInstaller forniti con Aspose.Slides per Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

Per congelare un programma con cx_Freeze, configurarlo per includere il pacchetto radice dell’estensione Aspose.Slides per Python via .NET che stai usando. Questo garantisce che l’estensione e tutti i moduli dipendenti vengano copiati nella build insieme alla tua applicazione.

### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Using the Setup Script**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Devo avere Microsoft PowerPoint o .NET installati sulla macchina dell'utente?**

No, PowerPoint non è necessario. Aspose.Slides è un motore autonomo; il pacchetto Python fornisce tutto il necessario come estensione per CPython. L'utente non deve installare .NET separatamente.

**Come devo allegare correttamente la licenza a un'applicazione congelata?**

Puoi memorizzare il file XML della licenza accanto all'eseguibile o incorporarlo come risorsa e caricarlo da un percorso accessibile prima della prima chiamata API. Importante: non modificare il contenuto dell'XML (nemmeno le interruzioni di riga).

**Cosa devo fare se i caratteri vengono visualizzati diversamente dopo la compilazione rispetto allo sviluppo?**

Assicurati che i caratteri che utilizzi siano disponibili nell'ambiente di destinazione (inclusi o installati nel sistema) e che i loro percorsi siano risolti correttamente a runtime; il comportamento dei caratteri è particolarmente sensibile su Linux.