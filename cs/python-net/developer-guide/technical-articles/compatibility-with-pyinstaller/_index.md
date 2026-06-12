---
title: Kompatibilita s PyInstaller a cx_Freeze
linktitle: Kompatibilita s PyInstaller
type: docs
weight: 122
url: /cs/python-net/compatibility-with-pyinstaller/
keywords:
- kompatibilita
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Balíček Aspose.Slides for Python via .NET pomocí PyInstalleru. Postupujte podle tohoto návodu k zabalení, konfiguraci a řešení problémů vaší aplikace do samostatného spustitelného souboru."
---
## **Úvod**

Aspose.Slides for Python via .NET jsou standardní rozšíření Pythonu v C, takže je lze „zmrazit“ jako závislosti programu pomocí nástrojů jako PyInstaller a cx_Freeze (nebo podobných). To vám umožní vytvořit spustitelné soubory z vašich Python skriptů. Tyto nástroje se nazývají „freezery“, protože zabalí váš kód a jeho závislosti do jediného distribuovatelného souboru, který běží na jiných počítačích, aniž by vyžadoval instalaci Pythonu nebo další knihovny. Tento přístup zjednodušuje distribuci vašich Python aplikací.

Zmrazení rozšíření Aspose.Slides for Python via .NET jako závislosti je ilustrováno níže jednoduchým programem, který používá Aspose.Slides.

## **PyInstaller**

Obecně není potřeba žádná speciální úprava při balení programu, který závisí na rozšíření Aspose.Slides for Python via .NET. Když program importuje rozšíření způsobem, který PyInstalleru je viditelný, rozšíření bude zahrnuto do balíčku. Vzhledem k tomu, že Aspose.Slides for Python via .NET obsahuje PyInstaller háčky, jeho závislosti jsou automaticky detekovány a zkopírovány do balíčku.

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

Nicméně PyInstaller může občas přehlédnout skryté importy — moduly, které jsou importovány dynamicky nebo nepřímo vaším kódem. Pro zahrnutí skrytého importu použijte možnosti PyInstalleru. Závislosti rozšíření jsou specifikovány v PyInstaller háčcích, které jsou součástí Aspose.Slides for Python via .NET.

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

Pro zmrazení programu pomocí cx_Freeze nakonfigurujte jej tak, aby zahrnoval kořenový balíček rozšíření Aspose.Slides for Python via .NET, které používáte. Tím se zajistí, že rozšíření a všechny závislé moduly budou zkopírovány do sestavení spolu s vaší aplikací.

### **Použití skriptu cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Použití setup skriptu**

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

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint nebo .NET na počítači uživatele?**

Ne, PowerPoint není vyžadován. Aspose.Slides je samostatný engine; Python balíček obsahuje vše potřebné jako rozšíření pro CPython. Uživatel nepotřebuje instalovat .NET samostatně.

**Jak správně připojit licenci k zmrazené aplikaci?**

Licenci ve formátu XML můžete uložit vedle spustitelného souboru nebo ji vložit jako zdroj a načíst z přístupné cesty před první volání API. Důležité: neprovádějte žádné úpravy obsahu XML (ani ne měňte konce řádků).

**Co mám dělat, když se po sestavení písma vykreslují odlišně oproti vývoji?**

Ujistěte se, že písma, která používáte, jsou dostupná v cílovém prostředí (zabalená nebo nainstalovaná v systému) a že jejich cesty jsou během běhu správně rozpoznány; chování písem je na Linuxu obzvláště citlivé.