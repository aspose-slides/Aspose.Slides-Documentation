---
title: Renderizar apresentações com fontes de fallback em JavaScript
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/nodejs-java/render-presentation-with-fallback-font/
keywords:
- fonte de fallback
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderizar apresentações com fontes de fallback no Aspose.Slides para Node.js – mantenha o texto consistente em PPT, PPTX e ODP com exemplos de código JavaScript passo a passo."
---
## **Visão geral**

O Aspose.Slides permite renderizar apresentações usando regras de fontes de fallback. Este artigo mostra como criar uma coleção de regras de fontes de fallback, modificar suas regras removendo ou adicionando fontes de fallback e atribuir a coleção usando o método `FontsManager.setFontFallBackRulesCollection`.

Depois que a coleção de regras de fontes de fallback é atribuída ao `FontsManager` da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar uma miniatura de slide e salvá‑la como uma imagem PNG.

## **Renderizar um slide usando regras de fontes de fallback**

O exemplo a seguir inclui estas etapas:

1. Nós [criamos a coleção de regras de fontes de fallback](/slides/pt/nodejs-java/create-fallback-fonts-collection/).
1. [Remover](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) uma regra de fonte de fallback e [addFallBackFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a outra regra.
1. Defina a coleção de regras para [getFontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
1. Com o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) podemos salvar a apresentação no mesmo formato ou salvá‑la em outro. Depois que a coleção de regras de fontes de fallback é definida no [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontsManager), essas regras são aplicadas durante quaisquer operações na apresentação: salvar, renderizar, converter, etc.

```javascript
// Criar nova instância de uma coleção de regras
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// create a number of rules
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Tentando remover a fonte FallBack "Tahoma" das regras carregadas
    fallBackRule.remove("Tahoma");
    // E atualizar as regras para o intervalo especificado
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Também podemos remover quaisquer regras existentes da lista
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Atribuindo uma lista de regras preparada para uso
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Renderizando miniatura usando a coleção de regras inicializada e salvando em JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Salvar a imagem no disco em formato JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Saiba mais sobre como [Converter PPT e PPTX para JPG em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}