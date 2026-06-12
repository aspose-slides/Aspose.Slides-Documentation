---
title: Instalace
type: docs
weight: 70
url: /cs/python-net/installation/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- použít Aspose.Slides
- instalace Aspose.Slides
- Windows
- macOS
- Python
description: "Zjistěte, jak rychle nainstalovat Aspose.Slides for Python via .NET. Praktický průvodce krok za krokem, systémové požadavky a ukázky kódu — začněte ještě dnes pracovat s prezentacemi PowerPoint!"
---
## **Přehled**

Balíček Aspose.Slides for Python via .NET obsahuje všechny nezbytné knihovny .NET, takže není potřeba instalovat .NET samostatně. To zjednodušuje proces nastavení a umožňuje vývojářům okamžitě začít pracovat s prezentacemi. Je však důležité poznamenat, že v závislosti na vašem operačním systému nebo prostředí můžete stále potřebovat nainstalovat některé platformově specifické závislosti požadované .NET. Navíc je nutné splnit určité systémové požadavky, aby byl balíček plně kompatibilní a správně fungoval.

## **Windows**

**Systémové požadavky**

Zkontrolujte a potvrďte, že specifikace vašeho počítače splňují nebo přesahují [systémové požadavky](/slides/cs/python-net/system-requirements/).

### **Instalace Aspose.Slides**

`pip` je nejjednodušší způsob, jak stáhnout a nainstalovat [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) ve Windows.

Pro instalaci Aspose.Slides spusťte následující příkaz:

```sh
pip install aspose-slides
```

**Použití Aspose.Slides**

Otestujte instalaci Aspose.Slides spuštěním následujícího kódu, který vytvoří prezentaci PowerPoint:

```python
# Importujte modul Aspose.Slides for Python via .NET.
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Systémové požadavky**

Zkontrolujte a potvrďte, že specifikace vašeho počítače splňují nebo přesahují [systémové požadavky](/slides/cs/python-net/system-requirements/).

### **Předpoklady**

**Python se sdílenými knihovnami**

Existuje několik způsobů, jak nainstalovat Python na macOS, ale důrazně doporučujeme použít [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos).

Po instalaci a konfiguraci **pyenv** nainstalujte Python se sdílenými knihovnami spuštěním následujících příkazů v aplikaci Terminal:

1. Nainstalujte Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Nastavte jej jako globální verzi Pythonu:

```sh
pyenv global 3.9.13
```

3. Nastavte jej jako verzi Pythonu pro konkrétní shell:

```sh
pyenv shell 3.9.13
```

4. Vytvořte symbolický odkaz na knihovnu libpython v systémovém adresáři knihoven:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Poznámka: Je vyžadován Python 3.5 nebo novější. Verze 3.9.13 je zde použita pouze jako příklad.

**Instalace knihovny libgdiplus**

Knihovna **libgdiplus** je implementací Windows GDI+ pro macOS a Linux, na kterou .NET spoléhá pro grafickou funkčnost na těchto platformách.  
Aby bylo možné tuto knihovnu nainstalovat na macOS, spusťte následující příkaz:

```sh
brew install mono-libgdiplus
```

### **Instalace Aspose.Slides**

`pip` je nejjednodušší způsob, jak stáhnout a nainstalovat [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) na macOS.

Pro instalaci Aspose.Slides spusťte následující příkaz:

```sh
pip install aspose-slides
```

**Použití Aspose.Slides**

Otestujte instalaci Aspose.Slides spuštěním následujícího kódu, který vytvoří prezentaci PowerPoint:

```python
# Importujte modul Aspose.Slides for Python via .NET.
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu nainstalovat Aspose.Slides ve virtuálním prostředí?**

Ano, můžete jej nainstalovat v libovolném virtuálním prostředí Pythonu pomocí `pip`. Jen se ujistěte, že prostředí má přístup k požadovaným nativním závislostem v závislosti na vašem OS.

**Mohu používat Aspose.Slides v Docker kontejnerech?**

Ano, ale musíte zajistit, že váš Docker image obsahuje potřebné nativní knihovny (**libgdiplus**, fontové balíčky atd.) a správnou verzi Pythonu.

**Existuje bezplatná verze nebo omezení zkušební verze?**

Ano, ve výchozím nastavení Aspose.Slides běží v evaluačním režimu, který umisťuje vodoznaky a může mít další omezení. Pro odstranění omezení je potřeba použít platnou [licenci](/slides/cs/python-net/licensing/).