---
title: Gerenciar Campos de Texto em Apresentações PowerPoint em PHP
linktitle: Campos de Texto
type: docs
weight: 52
url: /pt/php-java/text-fields/
keywords:
- campo de texto
- texto automático
- número do slide
- data e hora
- cabeçalho
- rodapé
- porção de texto
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Crie, inspecione, modifique e remova campos de texto em apresentações PowerPoint com Aspose.Slides para PHP via Java. Preserve a formatação e verifique os arquivos PPTX e PPT salvos."
---
## **Visão geral**

Um parágrafo de texto consiste em porções. Uma [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) comum contém texto literal; uma porção de campo também possui um [Field](https://reference.aspose.com/slides/pt/php-java/aspose.slides/field/) cujo tipo identifica um valor atualizado automaticamente, como um número de slide ou data. Duas porções podem exibir os mesmos caracteres enquanto apenas uma contém um campo.

Use [Portion::getField](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getField) para distingui‑las: ele é `null` para texto comum. [Portion::addField](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#addField) converte uma porção existente em um campo. Mantenha um rótulo e seu valor dinâmico em porções separadas para que a conversão do valor não substitua também o rótulo.

Este guia cobre campos dentro do texto, sua formatação e como salvá‑los em PPTX e PPT. Para quadros de texto e parágrafos, veja [Manage Text](/slides/pt/php-java/manage-text/).

## **Criar um Campo de Número de Slide**

O exemplo completo a seguir cria uma caixa de texto contendo um rótulo literal `Slide ` seguido por um número atualizado automaticamente. Ele define o tamanho, peso e cor do número antes de adicionar o campo, então reabre a apresentação salva e verifica o tipo, texto e formatação do campo. Nenhum arquivo de entrada é necessário.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

A nova apresentação começa com o número de slide 1, portanto o texto é `Slide 1`, e ambas as verificações imprimem `true`. O número permanece um campo após reabrir; não é um literal `1`. Os índices na verificação referem‑se à forma e às porções criadas por este exemplo.

## **Escolher um Tipo de Campo**

[FieldType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/) fornece os seguintes métodos para obter valores predefinidos. Passe o valor apropriado para [addField](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#addField).

| Método | Propósito |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getSlideNumber) | O número atual do slide. |
| [getDateTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getDateTime) | Data/hora no formato padrão do aplicativo de renderização. |
| [getDateTime1](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getDateTime9) | Formatos de data predefinidos ou combinados de data/hora. |
| [getDateTime10](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getDateTime13) | Formatos de hora predefinidos, com opções para segundos e relógio de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getHeader) | Um campo de cabeçalho; veja as limitações de placeholder e formato abaixo. |
| [getFooter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getFooter) | Um campo de rodapé. |

Por exemplo, [getDateTime3](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getDateTime3) representa um dia, nome completo do mês e ano em inglês. Estes são formatos de campo predefinidos, não strings arbitrárias de formato de data do PHP. O idioma definido com [setLanguageId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) e o aplicativo que processa a apresentação podem afetar o resultado exibido.

## **Criar um Campo a partir de uma String Interna**

A sobrecarga de string de [addField](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#addField) aceita um identificador de campo interno. Use‑a quando precisar preservar um identificador fornecido por outro aplicativo que não tem valor predefinido. Você também pode construir um [FieldType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#FieldType) a partir do identificador. [FieldType::getInternalString](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fieldtype/#getInternalString) expõe esse identificador para inspeção.

Este exemplo armazena um campo específico de aplicação `custom-report-id` com o texto de reserva `Report-042`. O identificador não registra um cálculo: Aspose.Slides não gera IDs de relatório para um tipo desconhecido. O aplicativo que entende esse identificador deve fornecer seu significado e atualizar seu valor.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Após esta ida e volta em PPTX, o tipo é `custom-report-id` e o texto é `Report-042`. Passar uma string como `Y-m-d` nomearia um tipo de campo; não configuraria um formato de data customizado. Para uma data fixa em um formato arbitrário, use texto comum.

## **Inspecionar, Modificar e Remover Campos de Data/Hora**

Altere um campo existente através de [Field::setType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/field/#setType). Verifique se o campo existe antes de acessar seu tipo. Para interromper atualizações automáticas, chame [Portion::removeField](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#removeField). Isso mantém a porção e seu texto atual enquanto remove a associação ao campo. Se precisar de um valor fixo específico, atribua esse texto após remover o campo.

Para a configuração da API associada ao processamento de campos de data/hora, veja [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#setCurrentDateTime). O exemplo abaixo usa uma data de aprovação explícita ao converter um campo em texto comum.

Baixe [sample.pptx](sample.pptx) e coloque‑o no diretório de trabalho do JavaBridge, ou passe seu caminho absoluto ao construtor da apresentação. Ele contém duas formas de texto nomeadas, `UpdatedAt` e `ApprovedDate`, cada uma com um campo de data/hora, além de rótulos de texto comuns. O exemplo a seguir percorre as formas de texto de nível superior em slides regulares. Ele altera os campos de data/hora para um formato de data longa e os coloca em itálico, preservando sua outra formatação. Apenas os campos em `ApprovedDate` tornam‑se texto fixo.

O exemplo reconhece os identificadores internos incorporados `datetime` e `datetime1` até `datetime13`. Grupos, tabelas, notas, layouts e mestres requerem percorrer seus próprios contêineres de texto e estão fora do escopo deste exemplo.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Após reabrir, `UpdatedAt` tem o tipo `datetime3` e permanece dinâmico. `ApprovedDate` não possui campo e contém `05 April 2030`. Ambas as porções de data estão em itálico, e seu tamanho de fonte original, configuração de negrito e cor permanecem intactos. Os rótulos de texto comuns permanecem inalterados. A verificação lê a primeira porção das duas formas conhecidas na amostra fornecida.

## **Preservar Formatação de Texto**

Trabalhe com a porção existente ao adicionar, mudar o tipo ou remover um campo. Essas operações mantêm a formatação da porção. Use [Portion::getPortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getPortionFormat) para alterar somente as propriedades necessárias, como nos exemplos para cor ou itálico.

Evite reconstruir um quadro de texto inteiro apenas para atualizar um campo: isso pode perder os limites originais das porções e sua formatação individual. Também distinga formatação definida explicitamente da herdada do parágrafo, layout ou tema. Veja [Text Formatting](/slides/pt/php-java/text-formatting/) para opções de formatação mais amplas.

## **Campos e Placeholders de Cabeçalho/Rodapé**

Um campo faz parte de uma porção de texto. Um placeholder é uma forma com um papel na apresentação, como rodapé ou número de slide. Adicionar um campo a uma caixa de texto comum não transforma essa forma em placeholder.

Os gerenciadores de cabeçalho/rodapé controlam o texto e a visibilidade dos placeholders em slides, layouts e mestres, incluindo a propagação para slides dependentes. Um campo numérico em uma caixa de texto personalizada pode ser útil mesmo quando você não usa o placeholder de número de slide. Por outro lado, alterar a visibilidade do placeholder não remove um campo de uma caixa de texto não relacionada.

Os tipos predefinidos de cabeçalho e rodapé não criam os placeholders correspondentes nem fornecem seu conteúdo. Em particular, um slide regular do PowerPoint não tem placeholder de cabeçalho; cabeçalhos pertencem a páginas de notas e folhetos. Não presuma que um campo de cabeçalho ou rodapé em uma forma arbitrária obterá automaticamente o texto configurado por um gerenciador de placeholder. Para esse fluxo, veja [Presentation Headers and Footers](/slides/pt/php-java/presentation-header-and-footer/).

## **Limitações do PPTX e PPT**

Verifique tanto o tipo de campo quanto o texto resultante após salvar e reabrir. Preservar um identificador não prova que um aplicativo pode calcular ou exibir seu valor.

| Formato | Comportamento do campo e limitações |
|---|---|
| PPTX | Armazena identificadores internos de campo ao lado do texto do campo. Nos testes de ida‑e‑volta, os tipos predefinidos e o identificador customizado usado acima sobreviveram ao salvamento e reabertura. O tipo customizado desconhecido manteve seu texto de reserva; não adquiriu lógica de cálculo automática. Outro aplicativo pode tratar identificadores não suportados de forma diferente. |
| PPT | Usa representações de campo legadas e tem compatibilidade mais limitada. Nos testes de ida‑e‑volta, os campos de número de slide e os campos de data/hora predefinidos sobreviveram ao salvamento e reabertura. Um campo customizado em uma caixa de texto de slide comum reabriu com seu identificador, mas com `*` como texto; um campo de cabeçalho no mesmo contexto também produziu `*`. Não confie que campos customizados ou contextos de campo não suportados mantenham seu texto visível. |

Para saída portátil e fixa, converta campos não suportados em texto comum e atribua explicitamente o valor desejado antes de salvar. Isso preserva o texto escolhido, mas interrompe intencionalmente as atualizações automáticas. Teste também o aplicativo de destino quando sua própria recalculação de campos fizer parte do seu fluxo de trabalho.

## **Perguntas Frequentes**

**Como posso saber se um número ou data exibido é um campo?**

Inspecione [Portion::getField](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getField). Um valor não nulo identifica um campo; o texto exibido sozinho não pode dizer isso.

**Remover um campo remove seu texto ou formatação?**

Não. [removeField](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#removeField) converte a porção existente em texto comum. Atribua um valor explícito depois, se precisar de uma data fixa ou texto de reserva específico.

**Uma string interna pode definir um novo formato de data ou fórmula?**

Não. Ela identifica um tipo de campo. Um identificador desconhecido não fornece um avaliador nem um padrão de formato de data do PHP. Use um tipo predefinido suportado ou formate o valor você mesmo como texto comum.

**Por que verificar novamente uma apresentação após salvá‑la?**

Identificadores de campo, texto calculado e formatação são coisas distintas a serem verificadas. A conversão de formato pode mudar o resultado visível mesmo quando o identificador do campo ainda está presente.