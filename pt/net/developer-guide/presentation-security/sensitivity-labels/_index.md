---
title: Gerenciar Rótulos de Sensibilidade em Apresentações PowerPoint no .NET
linktitle: Rótulos de Sensibilidade
type: docs
weight: 50
url: /pt/net/sensitivity-labels/
keywords:
- rótulo de sensibilidade
- Microsoft Purview
- Proteção de Informação da Microsoft
- metadados MIP
- marcação de conteúdo
- proteção de informação
- governança de documentos
- PowerPoint
- PPTX
- segurança de apresentação
- .NET
- C#
- Aspose.Slides
description: "Leia, adicione, atualize, remova e migre rótulos de sensibilidade do Microsoft Purview em apresentações PowerPoint PPTX com Aspose.Slides para .NET."
---
## **Visão Geral**

Os rótulos de sensibilidade do Microsoft Purview ajudam as organizações a classificar e governar documentos. Durante o processamento automatizado de apresentações, um aplicativo pode precisar preservar um rótulo existente, aplicar um rótulo selecionado por uma política, atualizar seu estado ou migrar metadados de rótulo gravados por um fluxo de trabalho mais antigo do Microsoft Information Protection (MIP).

Aspose.Slides expõe metadados modernos de rótulos de sensibilidade por meio de [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sensitivitylabels/). Essa propriedade devolve um [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/) que pode ser inspecionado e modificado antes de a apresentação ser salva como PPTX.

{{% alert color="info" title="Note" %}}
Os identificadores de rótulo de sensibilidade e as informações de política são definidos pela sua configuração do Microsoft Purview. Valide a disponibilidade de rótulos e os requisitos de política no seu ambiente antes de adicionar ou migrar metadados. Os valores de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) descrevem as marcações de conteúdo associadas a um rótulo; eles não adicionam texto ou formas visíveis aos slides por si só.
{{% /alert %}}

## **Entender as Propriedades do Rótulo de Sensibilidade**

Cada [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/) contém os seguintes metadados:

| Propriedade | Finalidade |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/id/) | Identifica o rótulo de sensibilidade na política do Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/siteid/) | Identifica o site associado à política do rótulo. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isenabled/) | Indica se o rótulo está habilitado. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isremoved/) | Indica que o rótulo foi removido. Defina esta propriedade como `true` quando o estado de remoção precisar ser mantido nos metadados. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Especifica se o rótulo foi aplicado automaticamente ou por decisão do usuário. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Lista os tipos de marcação de conteúdo associados ao rótulo. |

A enumeração [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelassignmenttype/) descreve como um rótulo foi atribuído:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo padrão ou aplicado automaticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo aplicado por decisão do usuário, incluindo rótulos aplicados manualmente, recomendados e obrigatórios.

A enumeração [SensitivityLabelContentType](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) identifica a marcação associada a um rótulo:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | O rótulo foi aplicado por padrão ou automaticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de cabeçalho está associada ao rótulo. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de rodapé está associada ao rótulo. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de marca d'água está associada ao rótulo. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | A proteção por criptografia está associada ao rótulo. |

Vários tipos de marcação podem ser associados a um único rótulo.

## **Listar Rótulos de Sensibilidade Existentes**

Leia a coleção moderna de rótulos a partir de [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sensitivitylabels/) e itere sobre ela. O exemplo a seguir lista cada propriedade e marcação de conteúdo armazenadas para cada rótulo:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Adicionar um Rótulo de Sensibilidade com Marcações de Conteúdo**

Use [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/add/) passando o identificador do rótulo, o identificador do site, o estado habilitado e o método de atribuição. Após o método retornar o novo [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/), adicione os valores de marcação necessários por meio de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/).

O exemplo a seguir adiciona um rótulo selecionado manualmente associado a marcações de rodapé e marca d'água e, em seguida, salva o resultado como PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Atualizar um Rótulo de Sensibilidade**

As propriedades de [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/) são leitura/gravação, exceto que a coleção retornada por [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) é modificada por suas operações de lista. Após localizar o rótulo necessário, você pode atualizar seu identificador, identificador do site, estado habilitado, método de atribuição, estado de remoção e tipos de marcação de conteúdo. Salve a apresentação para persistir as alterações.

O exemplo a seguir atualiza o estado habilitado e o método de atribuição do primeiro rótulo:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Marcar um Rótulo de Sensibilidade como Removido**

Para preservar o fato de que um rótulo foi removido, encontre o rótulo e defina [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isremoved/) como `true`. Isso mantém a entrada do rótulo enquanto registra seu estado removido. Se, ao contrário, precisar excluir uma entrada da coleção moderna, use [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/removeat/); use [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/clear/) para excluir todas as entradas.

O exemplo a seguir marca um rótulo específico como removido e salva a apresentação atualizada:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Ler e Migrar Rótulos de Sensibilidade Legados do MIP**

Fluxos de trabalho baseados em MIP mais antigos podem armazenar metadados de rótulo de sensibilidade em propriedades de documento personalizadas em vez da coleção moderna de rótulos. Leia esses metadados com [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/getsensitivitylabels/). O método analisa as propriedades personalizadas legadas e devolve um array de objetos [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/).

Para migrar os metadados, adicione cada rótulo retornado à coleção moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/) por meio de [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/add/). Como a adição de um identificador de rótulo duplicado gera uma exceção, o exemplo verifica a coleção de destino antes de copiar cada rótulo. Você pode acrescentar validações adicionais para confirmar que cada rótulo legado ainda existe na política Purview atual.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

A migração copia os objetos de rótulo analisados para a coleção moderna. Não é necessário limpar todas as propriedades de documento personalizadas, de modo que metadados de documento não relacionados permanecem intactos. Use [IPresentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/save/) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) para gravar os metadados modernos de rótulo em um arquivo PPTX.

## **FAQ**

**Adicionar um tipo de marcação de conteúdo cria um cabeçalho, rodapé ou marca d'água visível nos slides?**

Não. Os valores adicionados por meio de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) descrevem as marcações associadas ao rótulo de sensibilidade. Eles não criam texto ou formas visíveis na apresentação. Adicione o conteúdo de slide correspondente separadamente se o seu fluxo de trabalho precisar renderizar essas marcações.

**Qual a diferença entre marcar um rótulo como removido e excluí‑lo da coleção?**

Definir [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isremoved/) como `true` mantém a entrada do rótulo e registra seu estado removido. Chamar [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/removeat/) exclui a entrada da coleção moderna. Escolha a operação que corresponde aos requisitos de retenção de metadados da sua organização.

**Uma apresentação pode conter metadados MIP legados e rótulos de sensibilidade modernos simultaneamente?**

Sim. Rótulos legados podem permanecer em propriedades de documento personalizadas enquanto os rótulos modernos ficam disponíveis via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sensitivitylabels/). Use [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/getsensitivitylabels/) para ler os metadados legados e migrar somente os rótulos válidos que ainda não estejam presentes na coleção moderna.

**O que acontece quando um rótulo com o mesmo identificador é adicionado mais de uma vez?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/add/) lança uma `ArgumentException` quando a coleção já contém um rótulo com o mesmo identificador. Verifique os valores de [ISensitivityLabel.Id](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/id/) existentes antes de adicionar ou migrar rótulos.

**Qual formato de saída deve ser usado para preservar rótulos de sensibilidade atualizados?**

Salve a apresentação como PPTX chamando [IPresentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/save/) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/), conforme demonstrado nos exemplos acima.