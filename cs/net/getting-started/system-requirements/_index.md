---
title: Systémové požadavky
type: docs
weight: 60
url: /cs/net/system-requirements/
keywords:
- systémové požadavky
- podporované platformy
- cílové rámce
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zkontrolujte, co Aspose.Slides for .NET potřebuje před instalací: rámce, na které cílí jednotlivé balíčky NuGet, podporované operační systémy a procesory a knihovny a písma, které Linux vyžaduje."
---
## **Úvod**

Aspose.Slides for .NET je samostatná knihovna: nepotřebuje Microsoft PowerPoint ani Microsoft Office. Je distribuována jako dva balíčky NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) a [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Oba poskytují stejné jmenné prostory a třídy Aspose.Slides; liší se v cílových rámcích a ve způsobu vykreslování snímků, což určuje, kde běží a co potřebují.

Tento článek uvádí verze .NET a platformy, které každý balíček podporuje, a systémové knihovny a písma, které Linux potřebuje, a končí krátkým programem, který kontroluje vaše nastavení. Pro přidání balíčku do projektu viz [Installation](/slides/cs/net/installation/).

## **Podporované verze .NET**

Každý balíček obsahuje jedno sestavení Aspose.Slides pro konkrétní cílový rámec a NuGet vybere sestavení, které odpovídá cílovému rámci vašeho projektu.

| Balíček | Cílové frameworky v balíčku | Váš projekt může cílit na |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 nebo novější; .NET 6 nebo novější, včetně .NET 8, .NET 9 a .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 nebo novější, včetně .NET 8, .NET 9 a .NET 10 |

`netstandard2.0` sestavení umožňuje knihovně .NET Standard 2.0 odkazovat na Aspose.Slides.NET. Aplikace, která takovou knihovnu používá, spouští sestavení odpovídající vlastnímu cílovému rámci aplikace: např. aplikace .NET 8 spustí `net6.0` sestavení.

## **Podporované operační systémy a procesory**

**Aspose.Slides.NET** obsahuje pouze procesorem nezávislý (AnyCPU) spravovaný kód, takže běží na architektuře procesoru .NET runtime, který jej načte. Vykresluje snímky pomocí knihovny System.Drawing.Common od Microsoftu, kterou Microsoft podporuje [pouze na Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Na Linuxu tedy Aspose.Slides.NET potřebuje knihovnu `libgdiplus` a spouštěcí přepínač, popsaný v sekci [Linux](#linux). Běží na distribucích Linuxu, které poskytují `libgdiplus`, jako jsou Debian, Ubuntu a Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** vykresluje snímky pomocí vlastního grafického enginu. Engine je nativní knihovna, kterou balíček obsahuje v jedné verzi pro každou platformu, takže balíček běží pouze na těchto platformách:

| Operační systém | Procesory | Poznámky |
|---|---|---|
| Windows | x86, x64 | Windows na ARM64 není podporován. |
| Linux | x64, ARM64 | Vyžaduje glibc 2.23 nebo novější na x64 a glibc 2.39 nebo novější na ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform neběží na Alpine Linux ani na jiných distribucích postavených na musl místo glibc, ani na distribucích se starší glibc, jako je CentOS 7. Na těchto systémech použijte Aspose.Slides.NET.

Na Windows nativní knihovna Aspose.Slides.NET6.CrossPlatform používá runtime Microsoft Visual C++ (*MSVCP140.dll* a *VCRUNTIME140.dll*, plus *VCRUNTIME140_1.dll* na x64). Pokud tyto soubory chybí na cílovém počítači, nainstalujte [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Oba balíčky potřebují na Linuxu další systémové knihovny. Bez nich selže první příklad v [Create Presentations](/slides/cs/net/create-presentation/) s výjimkou místo uložení souboru. Níže uvedené příkazy jsou pro Debian a Ubuntu; na těchto distribucích každá knihovna také přináší písma DejaVu (`fonts-dejavu-core`), takže text se vykreslí bez dalších fontových balíčků.

### **Aspose.Slides.NET6.CrossPlatform**

Linuxová knihovna balíčku vyžaduje knihovnu `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Bez ní selže vytvoření [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) s `TypeInitializationException`, jehož vnitřní `DllNotFoundException` uvádí, že `libfontconfig.so.1` nelze otevřít.

Minimální základní obrazy také nemusí obsahovat `fontconfig`. Například základní obraz AWS Lambda pro .NET 8 neobsahuje ani `fontconfig`, ani žádná písma. V kontejnerovém obrazu postaveném na něm spusťte `dnf install -y fontconfig`, což také nainstaluje písma Noto Sans.

### **Aspose.Slides.NET**

Balíček na Linuxu vyžaduje dvě věci:

1. Knihovnu `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
```

2. Přepínač `System.Drawing.EnableUnixSupport`, který se povolí na začátku aplikace před jakýmkoli voláním Aspose.Slides. V souboru *Program.cs* s top-level statements jej umístěte za `using` direktivy:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Bez `libgdiplus` selže uložení prezentace s `TypeInitializationException`, jehož vnitřní `DllNotFoundException` uvádí, že `libgdiplus` nelze načíst. Bez přepínače je vnitřní výjimkou `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Přepínač funguje pouze se System.Drawing.Common 6, verzí, na které Aspose.Slides.NET závise. Microsoft jej odstranil v System.Drawing.Common 7. Pokud váš projekt odkazuje na System.Drawing.Common 7 nebo novější, ať už přímo nebo přes jiný balíček, Aspose.Slides.NET selže na Linuxu s `PlatformNotSupportedException` i když je `libgdiplus` nainstalován a přepínač povolen. V takovém případě použijte Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Na Alpine Linux použijte Aspose.Slides.NET s výše popsaným přepínačem. Alpine obrazy obvykle neobsahují žádná písma a samotný `libgdiplus` neinstaluje žádná, proto nainstalujte `libgdiplus` spolu s alespoň jedním fontovým balíčkem. Bez písem selže uložení prezentace s tímto chybovým hlášením:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Možnost 1: Písma DejaVu**

Doporučenou volbou je balíček `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Na aktuálních vydáních Alpine `ttf-dejavu` nainstaluje balíček `font-dejavu`, který také nainstaluje `fontconfig` a fontové nástroje, na nichž závisí.

**Možnost 2: Základní písma Microsoft**

Pokud vaše prezentace používají písma Microsoftu jako Arial, Times New Roman, Courier New nebo Verdana, místo toho nainstalujte základní písma Microsoftu. Krok `update-ms-fonts` stáhne písma během vytváření obrazu, takže sestavení potřebuje přístup k internetu:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Podpora globalizace**

Oba balíčky potřebují podporu globalizace .NET, kterou .NET na Linuxu poskytuje přes knihovny ICU. V [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) selže vytvoření [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) s `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Některé kontejnerové obrazy tuto režim zapínají. Například .NET runtime obrazy pro Alpine Linux (`runtime-deps`, `runtime`, a `aspnet`) nastavením `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` neobsahují ICU. V obrazu postaveném na nich nainstalujte ICU a režim vypněte:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Také se ujistěte, že ve vašem souboru projektu není nastavená vlastnost `InvariantGlobalization` na `true`.

## **Zkontrolujte své nastavení**

Pro ověření, že je balíček a jeho požadavky na místě, spusťte program, který uloží prezentaci a vykreslí snímek do obrázku. Ukládání a vykreslování používají grafickou knihovnu a písma, což jsou požadavky na Linux uvedené výše.

Vytvořte konzolovou aplikaci a přidejte balíček podle popisu v [Installation](/slides/cs/net/installation/), nahraďte obsah *Program.cs* kódem níže a spusťte `dotnet run`. Pokud používáte Aspose.Slides.NET na Linuxu, přidejte výrok přepínače `System.Drawing.EnableUnixSupport` uvedený v [Linux](#linux) za `using` direktivy. Program používá top-level statements a `using` deklarace, které vyžadují C# 9 nebo novější. Projekty cílící na .NET 6 nebo novější používají novější verzi C# ve výchozím nastavení; v projektu cílícím na .NET Framework přidejte `<LangVersion>latest</LangVersion>` do `PropertyGroup` v souboru projektu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Program přidá obdélník s textem na první snímek a uloží prezentaci jako *hello.pptx* pomocí metody [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/). Pak vykreslí snímek pomocí [GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/getimage/) a výsledek uloží jako *hello.png* pomocí [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/) ve formátu [ImageFormat.Png](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/). Měřítko 1 vykreslí jeden pixel na bod, takže výchozí 720 × 540 bodový snímek se stane 720 × 540 pixelovým obrázkem, přičemž text je viditelný uvnitř obdélníku. Bez licence oba soubory také obsahují zkušební vodoznak; viz [Licensing](/slides/cs/net/licensing/). Pokud některý požadavek chybí, program zastaví s jednou z výjimek popsaných v [Linux](#linux).

## **Vývojové nástroje**

Můžete vytvářet aplikace používající Aspose.Slides s jakýmkoli nástrojem, který podporuje cílový rámec vašeho projektu: .NET SDK a jeho CLI `dotnet` na Windows, Linuxu a macOS, nebo Visual Studio na Windows. [Installation](/slides/cs/net/installation/) popisuje obojí.

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a vykreslování?**

Ne, PowerPoint není vyžadován. Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/net/create-presentation/), úpravy, [konverzi](/slides/cs/net/convert-presentation/) a [vykreslování](/slides/cs/net/convert-powerpoint-to-png/) prezentací.

**Který balíček mám použít?**

Používejte Aspose.Slides.NET na Windows a Aspose.Slides.NET6.CrossPlatform na Linux a macOS. Na Alpine Linux, na Linuxových systémech s glibc starší než uvedené verze a v projektech cílených na .NET Framework použijte Aspose.Slides.NET. Do projektu přidejte jen jeden z těchto dvou balíčků.

**Jaká písma jsou potřebná pro správné vykreslování?**

Písma použité v prezentaci, nebo vhodné náhrady, musí být k dispozici v operačním systému. Na Linuxu a macOS nainstalujte fontové balíčky, které vaše prezentace potřebují, aby bylo zajištěno konzistentní vykreslování. Na Alpine Linux nainstalujte alespoň jeden fontový balíček kromě `libgdiplus`, jak je popsáno v [Alpine Linux](#alpine-linux).

**Proč se na Linuxu vlastní písmo vykreslí jako náhradní nebo chybějící text?**

Pokud soubor písma má nejednotné nebo poškozené záznamy v tabulce name, může linuxový zásobník pro výběr písma (FreeType/fontconfig) vybrat neplatný záznam, což vede k nevyřešenému písmu. Použití verze písma s opravenými záznamy name-table nebo instalace konzistentní náhrady problém vyřeší.