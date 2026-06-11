---
title: Kompatibilitet med PyInstaller och cx_Freeze
linktitle: Kompatibilitet med PyInstaller
type: docs
weight: 122
url: /sv/python-net/compatibility-with-pyinstaller/
keywords:
- kompatibilitet
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Paketera Aspose.Slides för Python via .NET med PyInstaller. Följ den här guiden för att samla, konfigurera och felsöka din app till en fristående körbar fil."
---
## **Introduktion**

Aspose.Slides för Python via .NET-utökningar är standard Python C-utökningar, så de kan frysas som programberoenden med verktyg som PyInstaller och cx_Freeze (eller liknande). Detta gör att du kan skapa körbara filer från dina Python‑skript. Sådana verktyg kallas “freezers” eftersom de paketerar din kod och dess beroenden i en enda distribuérbar fil som körs på andra maskiner utan att kräva en Python‑installation eller ytterligare bibliotek. Detta tillvägagångssätt förenklar distributionen av dina Python‑applikationer.

Att frysa en Aspose.Slides för Python via .NET-utökning som ett beroende illustreras nedan med ett enkelt program som använder Aspose.Slides.

## **PyInstaller**

Generellt krävs ingen speciell åtgärd när du paketerar ett program som beror på en Aspose.Slides för Python via .NET-utökning. När ett program importerar utökningen på ett sätt som är synligt för PyInstaller kommer utökningen att paketeras med programmet. Eftersom Aspose.Slides för Python via .NET inkluderar PyInstaller‑hooks upptäcks dess beroenden automatiskt och kopieras in i paketet.

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

Dock kan PyInstaller ibland missa dolda importer—moduler som importeras dynamiskt eller indirekt av din kod. För att inkludera en dold import, använd PyInstallers alternativ. Utökningens beroenden specificeras i de PyInstaller‑hooks som levereras med Aspose.Slides för Python via .NET.

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

För att frysa ett program med cx_Freeze, konfigurera det så att det inkluderar rotpaketet för den Aspose.Slides för Python via .NET-utökning du använder. Detta säkerställer att utökningen och alla beroende moduler kopieras in i bygget tillsammans med din applikation.

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

**Behöver jag Microsoft PowerPoint eller .NET installerat på användarens maskin?**

Nej, PowerPoint krävs inte. Aspose.Slides är en fristående motor; Python‑paketet levererar allt som behövs som en utökning för CPython. Användaren behöver inte installera .NET separat.

**Hur ska jag korrekt bifoga licensen till en fryst applikation?**

Du kan lagra licens‑XML‑filen bredvid den körbara filen eller bädda in den som en resurs och läsa in den från en åtkomlig sökväg innan det första API‑anropet. Viktigt: ändra inte XML‑innehållet (inte ens radbrytningar).

**Vad ska jag göra om teckensnitt renderas annorlunda efter byggandet jämfört med utvecklingsmiljön?**

Se till att de teckensnitt du använder finns tillgängliga i målmiljön (paketerade eller systeminstallerade) och att deras sökvägar lösts korrekt vid körning; teckensnittsbeteende är särskilt känsligt på Linux.