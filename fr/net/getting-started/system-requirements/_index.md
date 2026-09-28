---
title: Exigences système
type: docs
weight: 60
url: /fr/net/system-requirements/
keywords:
- exigences système
- plates-formes prises en charge
- frameworks cibles
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
- présentation
- .NET
- C#
- Aspose.Slides
description: "Vérifiez ce dont Aspose.Slides for .NET a besoin avant de l'installer : les frameworks ciblés par chaque package NuGet, les systèmes d'exploitation et processeurs pris en charge, ainsi que les bibliothèques et polices requises sous Linux."
---
## **Introduction**

Aspose.Slides for .NET est une bibliothèque autonome : elle ne nécessite pas Microsoft PowerPoint ni Microsoft Office. Elle est publiée sous forme de deux packages NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) et [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Les deux offrent les mêmes espaces de noms et classes Aspose.Slides ; ils diffèrent par les frameworks ciblés et par la façon dont ils dessinent les diapositives, ce qui détermine où ils s’exécutent et ce dont ils ont besoin.

Cet article répertorie les versions .NET et les plateformes prises en charge par chaque package ainsi que les bibliothèques système et les polices requises sous Linux, et se termine par un petit programme qui vérifie votre configuration. Pour ajouter un package à un projet, consultez [Installation](/slides/fr/net/installation/).

## **Versions .NET prises en charge**

Chaque package contient une compilation d’Aspose.Slides par framework cible, et NuGet sélectionne la compilation correspondant au framework cible de votre projet.

| Package | Frameworks cibles dans le package | Votre projet peut cibler |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 ou ultérieur ; .NET 6 ou ultérieur, y compris .NET 8, .NET 9 et .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 ou ultérieur, y compris .NET 8, .NET 9 et .NET 10 |

La compilation `netstandard2.0` permet à une bibliothèque de classes .NET Standard 2.0 de référencer Aspose.Slides.NET. Une application qui utilise une telle bibliothèque exécute la compilation qui correspond au framework cible de l’application : une application .NET 8, par exemple, exécutera la compilation `net6.0`.

## **Systèmes d'exploitation et processeurs pris en charge**

**Aspose.Slides.NET** ne contient que du code géré indépendant du processeur (AnyCPU), il s’exécute donc sur l’architecture du runtime .NET qui le charge. Il dessine les diapositives via la bibliothèque System.Drawing.Common de Microsoft, que Microsoft prend en charge **uniquement sous Windows** (https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Sous Linux, Aspose.Slides.NET a donc besoin de la bibliothèque `libgdiplus` et d’un commutateur de démarrage, décrits dans [Linux](#linux). Il fonctionne sur les distributions Linux qui fournissent `libgdiplus`, telles que Debian, Ubuntu et Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** dessine les diapositives avec son propre moteur graphique. Le moteur est une bibliothèque native que le package inclut dans une compilation par plateforme, de sorte que le package ne fonctionne que sur ces plateformes :

| Système d'exploitation | Processeurs | Remarques |
|---|---|---|
| Windows | x86, x64 | Windows sur ARM64 n’est pas pris en charge. |
| Linux | x64, ARM64 | Nécessite glibc 2.23 ou supérieur sur x64 et glibc 2.39 ou supérieur sur ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform ne fonctionne pas sur Alpine Linux ni sur d’autres distributions basées sur musl au lieu de glibc, ni sur des distributions avec une glibc plus ancienne, comme CentOS 7. Utilisez Aspose.Slides.NET sur ces systèmes.

Sous Windows, la bibliothèque native d’Aspose.Slides.NET6.CrossPlatform utilise le runtime Microsoft Visual C++ (*MSVCP140.dll* et *VCRUNTIME140.dll*, plus *VCRUNTIME140_1.dll* sur x64). Si ces fichiers manquent sur la machine cible, installez le [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Les deux packages nécessitent des bibliothèques système supplémentaires sous Linux. Sans elles, le premier exemple de [Create Presentations](/slides/fr/net/create-presentation/) échoue avec une exception au lieu d’enregistrer le fichier. Les commandes ci‑dessous concernent Debian et Ubuntu ; sur ces distributions, chaque bibliothèque installe également les polices DejaVu (`fonts-dejavu-core`), de sorte que le texte s’affiche sans paquets de polices supplémentaires.

### **Aspose.Slides.NET6.CrossPlatform**

La bibliothèque Linux du package requiert la bibliothèque `fontconfig` :

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Sans elle, la création d’une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) échoue avec une `TypeInitializationException` dont l’`DllNotFoundException` interne indique que `libfontconfig.so.1` ne peut pas être ouvert.

Les images de base minimales peuvent également ne pas contenir `fontconfig`. L’image de base AWS Lambda pour .NET 8, par exemple, ne contient ni `fontconfig` ni aucune police. Dans une image de conteneur construite dessus, exécutez `dnf install -y fontconfig`, ce qui installe aussi les polices Noto Sans.

### **Aspose.Slides.NET**

Le package nécessite deux éléments sous Linux :

1. La bibliothèque `libgdiplus` :

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. Le commutateur `System.Drawing.EnableUnixSupport`, activé au démarrage de votre application avant tout appel à Aspose.Slides. Dans un *Program.cs* avec des instructions de haut niveau, placez‑le après les directives `using` :

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Sans `libgdiplus`, l’enregistrement d’une présentation échoue avec une `TypeInitializationException` dont l’`DllNotFoundException` interne indique que `libgdiplus` ne peut pas être chargé. Sans le commutateur, l’exception interne est `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Le commutateur ne fonctionne qu’avec System.Drawing.Common 6, la version dont dépend Aspose.Slides.NET. Microsoft l’a supprimé dans System.Drawing.Common 7. Si votre projet référence System.Drawing.Common 7 ou une version ultérieure, directement ou via un autre package, Aspose.Slides.NET échoue sous Linux avec `PlatformNotSupportedException` même si `libgdiplus` est installé et le commutateur activé. Dans ce cas, utilisez Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Sous Alpine Linux, utilisez Aspose.Slides.NET avec le commutateur décrit ci‑dessus. Les images Alpine ne contiennent généralement aucune police, et `libgdiplus` seul n’installe aucune police, il faut donc installer `libgdiplus` avec au moins un paquet de polices. Sans police, l’enregistrement d’une présentation échoue avec l’erreur suivante :

```text
System.ArgumentException: Font '?' cannot be found.
```

**Option 1 : polices DejaVu**

L’option recommandée est le paquet `ttf-dejavu` :

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Sur les versions actuelles d’Alpine, `ttf-dejavu` installe le paquet `font-dejavu`, qui installe également `fontconfig` et les outils de police dont il dépend.

**Option 2 : polices Microsoft de base**

Si vos présentations utilisent des polices Microsoft telles qu’Arial, Times New Roman, Courier New ou Verdana, installez les polices de base Microsoft à la place. L’étape `update‑ms‑fonts` télécharge les polices lors de la construction de l’image, il faut donc que la construction dispose d’un accès Internet :

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Prise en charge de la mondialisation**

Les deux packages nécessitent la prise en charge de la mondialisation .NET, fournie sous Linux via les bibliothèques ICU. En [mode globalization‑invariant](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), la création d’une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) échoue avec `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Certaines images de conteneur activent ce mode. Les images runtime .NET pour Alpine Linux (`runtime-deps`, `runtime` et `aspnet`), par exemple, définissent `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` et n’incluent pas ICU. Dans une image construite à partir de celles‑ci, installez ICU et désactivez le mode :

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Assurez‑vous également que votre fichier projet ne définit pas la propriété `InvariantGlobalization` à `true`.

## **Vérifiez votre configuration**

Pour vérifier qu’un package et ses exigences sont présents, exécutez un programme qui enregistre une présentation et rend une diapositive sous forme d’image. L’enregistrement et le rendu utilisent la bibliothèque graphique et les polices, qui sont fournis par les exigences Linux décrites ci‑dessus.

Créez une application console et ajoutez le package comme indiqué dans [Installation](/slides/fr/net/installation/), remplacez le contenu de *Program.cs* par le code ci‑dessous, puis lancez `dotnet run`. Si vous utilisez Aspose.Slides.NET sous Linux, ajoutez l’instruction de commutateur `System.Drawing.EnableUnixSupport` montrée dans [Linux](#linux) après les directives `using`. Le programme utilise des instructions de haut niveau et des déclarations `using`, qui nécessitent C# 9 ou ultérieur. Les projets ciblant .NET 6 ou ultérieur utilisent par défaut une version plus récente de C# ; dans un projet ciblant .NET Framework, ajoutez `<LangVersion>latest</LangVersion>` à un `PropertyGroup` dans le fichier projet.

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

Le programme ajoute un rectangle avec du texte à la première diapositive et enregistre la présentation sous *hello.pptx* avec la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Il rend ensuite la diapositive avec [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) et enregistre le résultat sous *hello.png* avec [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) au format [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). Les facteurs d’échelle de 1 rendent un pixel par point, de sorte que la diapositive par défaut de 720 × 540 points devient une image de 720 × 540 pixels, le texte étant visible à l’intérieur du rectangle. Sans licence, les deux fichiers portent également un filigrane d’évaluation ; voir [Licensing](/slides/fr/net/licensing/). Si une exigence manque, le programme s’arrête avec l’une des exceptions décrites dans [Linux](#linux).

## **Outils de développement**

Vous pouvez créer des applications qui utilisent Aspose.Slides avec n’importe quel outil prenant en charge le framework cible de votre projet : le SDK .NET et son interface en ligne de commande `dotnet` sous Windows, Linux et macOS, ou Visual Studio sous Windows. [Installation](/slides/fr/net/installation/) décrit les deux approches.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint pour les conversions et le rendu ?**

Non, PowerPoint n’est pas requis. Aspose.Slides est un moteur autonome pour [créer](/slides/fr/net/create-presentation/), modifier, [convertir](/slides/fr/net/convert-presentation/) et [rendre](/slides/fr/net/convert-powerpoint-to-png/) des présentations.

**Quel package dois‑je utiliser ?**

Utilisez Aspose.Slides.NET sous Windows et Aspose.Slides.NET6.CrossPlatform sous Linux et macOS. Sous Alpine Linux, sur les systèmes Linux dont la glibc est plus ancienne que les versions indiquées ci‑dessus, et dans les projets ciblant .NET Framework, utilisez Aspose.Slides.NET. Ajoutez uniquement l’un des deux packages à un projet.

**Quelles polices sont nécessaires pour un rendu correct ?**

Les polices utilisées dans la présentation, ou des substituts appropriés, doivent être disponibles dans le système d’exploitation. Sous Linux et macOS, installez les paquets de polices dont vos présentations ont besoin pour obtenir un rendu cohérent. Sous Alpine Linux, installez au moins un paquet de polices en plus de `libgdiplus`, comme indiqué dans [Alpine Linux](#alpine-linux).

**Pourquoi une police personnalisée s’affiche-t‑elle comme police de secours ou texte manquant sous Linux ?**

Si le fichier de police contient des entrées de table de noms incohérentes ou corrompues, la pile de correspondance de polices Linux (FreeType/fontconfig) peut sélectionner un enregistrement invalide, entraînant une police non résolue. L’utilisation d’une version de police avec des tables de noms corrigées ou l’installation d’un remplacement cohérent résout le problème.