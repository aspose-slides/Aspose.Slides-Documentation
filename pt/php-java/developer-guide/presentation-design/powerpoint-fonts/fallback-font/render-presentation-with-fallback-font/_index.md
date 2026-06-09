---
title: Renderizar apresentações com fontes de fallback em PHP
linktitle: Renderizar apresentações
type: docs
weight: 30
url: /pt/php-java/render-presentation-with-fallback-font/
keywords:
- fonte de fallback
- renderizar PowerPoint
- renderizar apresentação
- renderizar slide
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Renderize apresentações com fontes de fallback no Aspose.Slides para PHP via Java – mantenha o texto consistente em PPT, PPTX e ODP com exemplos de código passo a passo."
---
## **Visão geral**

Aspose.Slides permite renderizar apresentações usando regras de fonte de fallback. Este artigo mostra como criar uma coleção de regras de fontes de fallback, modificar suas regras removendo ou adicionando fontes de fallback e atribuir a coleção ao método `FontsManager::setFontFallBackRulesCollection`.

Depois que a coleção de regras de fontes de fallback é atribuída ao `FontsManager` da apresentação, as regras são aplicadas durante operações como salvar, renderizar e converter a apresentação. O exemplo demonstra como usar as regras configuradas ao renderizar a miniatura de um slide e salvá‑la como imagem PNG.

## **Renderizar um Slide Usando Regras de Fonte de Fallback**

O exemplo a seguir inclui estas etapas:

1. Nós [criamos a coleção de regras de fontes de fallback](/slides/pt/php-java/create-fallback-fonts-collection/).
2. [Remova](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) uma regra de fonte de fallback e [addFallBackFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) a outra regra.
3. Defina a coleção de regras em [getFontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) método.
4. Com o método [Presentation.save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#save-java.lang.String-int-) podemos salvar a apresentação no mesmo formato ou em outro. Depois que a coleção de regras de fontes de fallback é definida em [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontsManager), essas regras são aplicadas durante quaisquer operações sobre a apresentação: salvar, renderizar, converter, etc.

```php
  # Criar nova instância de uma coleção de regras
  $rulesList = new FontFallBackRulesCollection();
  # criar um número de regras
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Tentando remover a fonte de fallback "Tahoma" das regras carregadas
    $fallBackRule->remove("Tahoma");
    # E atualizar as regras para o intervalo especificado
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Também podemos remover quaisquer regras existentes da lista
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Atribuindo uma lista de regras preparada para uso
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Renderizando miniatura usando a coleção de regras inicializada e salvando como JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Salvar a imagem no disco em formato JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Saiba mais sobre como [Converter PPT e PPTX para JPG em PHP](/slides/pt/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}