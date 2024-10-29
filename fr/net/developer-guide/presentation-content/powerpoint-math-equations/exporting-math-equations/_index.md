---
title: Exportation des Équations Mathématiques
type: docs
weight: 30
url: /fr/net/exporting-math-equations/
keywords: "Exporter des équations mathématiques, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Exporter des équations mathématiques PowerPoint en C# ou .NET"
---

Aspose.Slides pour .NET vous permet d'exporter des équations mathématiques depuis des présentations. Par exemple, vous pourriez avoir besoin d'extraire les équations mathématiques sur des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou plateforme.

{{% alert color="primary" %}} 

Vous pouvez exporter des équations vers MathML, un format ou standard populaire pour les équations mathématiques et un contenu similaire visible sur le web et dans de nombreuses applications. 

{{% /alert %}}

Alors que les humains écrivent facilement le code pour certains formats d'équation comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier est destiné à être généré automatiquement par des applications. Les programmes lisent et analysent facilement MathML car son code est en XML, donc MathML est souvent utilisé comme format de sortie et d'impression dans de nombreux domaines.

Ce code d'exemple vous montre comment exporter une équation mathématique d'une présentation vers MathML :

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```