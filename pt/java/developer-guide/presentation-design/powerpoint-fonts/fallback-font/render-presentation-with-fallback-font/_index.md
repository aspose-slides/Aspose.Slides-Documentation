---
title: Renderizar apresentações com fontes de fallback em Java
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/java/render-presentation-with-fallback-font/
keywords:
- fonte de fallback
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Renderizar apresentações com fontes de fallback no Aspose.Slides para Java – mantenha o texto consistente em PPT, PPTX e ODP com exemplos de código Java passo a passo."
---
## **Visão geral**

Aspose.Slides permite que você renderize apresentações usando regras de fonte de fallback. Este artigo mostra como criar uma coleção de regras de fonte de fallback, modificar suas regras removendo ou adicionando fontes de fallback e atribuir a coleção usando o método `FontsManager.setFontFallBackRulesCollection`.

Depois que a coleção de regras de fonte de fallback é atribuída ao `FontsManager` da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar uma miniatura de slide e salvá‑la como uma imagem JPEG.

## **Renderizar um Slide Usando Regras de Fonte de Fallback**

O exemplo a seguir inclui estas etapas:

1. Criamos [criar coleção de regras de fonte de fallback](/slides/pt/java/create-fallback-fonts-collection/).
1. [Remover](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) uma regra de fonte de fallback e [addFallBackFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a outra regra.
1. Defina a coleção de regras em [getFontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
1. Com o método [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#save-java.lang.String-int-) podemos salvar a apresentação no mesmo formato ou salvá‑la em outro. Depois que a coleção de regras de fonte de fallback é definida em [FontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsManager), essas regras são aplicadas durante quaisquer operações sobre a apresentação: salvar, renderizar, converter, etc.

```java
import com.aspose.slides.*;

// Cria uma nova instância de uma coleção de regras
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Tentando remover a fonte de fallback "Tahoma" das regras carregadas
    fallBackRule.remove("Tahoma");

    // E atualizar as regras para o intervalo especificado
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Também podemos remover quaisquer regras existentes da lista, mantendo ao menos uma regra para renderizar
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Atribuindo uma lista de regras preparada para uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderizando a miniatura usando a coleção de regras inicializada e salvando como JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Salvar a imagem no disco em formato JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Leia mais sobre como [Converter PPT e PPTX para JPG em Java](/slides/pt/java/convert-powerpoint-to-jpg/).
{{% /alert %}}