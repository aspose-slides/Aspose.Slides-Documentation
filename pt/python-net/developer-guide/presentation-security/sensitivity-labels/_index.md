---
title: Gerenciar rótulos de sensibilidade em apresentações PowerPoint em Python
linktitle: Rótulos de Sensibilidade
type: docs
weight: 50
url: /pt/python-net/sensitivity-labels/
keywords:
- rótulo de sensibilidade
- Microsoft Purview
- Microsoft Information Protection
- metadados MIP
- marcação de conteúdo
- proteção de informação
- governança de documentos
- PowerPoint
- PPTX
- segurança de apresentações
- Python
- Aspose.Slides
description: "Leia, adicione, atualize, remova e migre rótulos de sensibilidade do Microsoft Purview em apresentações PowerPoint PPTX com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Os rótulos de sensibilidade do Microsoft Purview ajudam as organizações a classificar e governar documentos. Durante o processamento automatizado de apresentações, um aplicativo pode precisar preservar um rótulo existente, aplicar um rótulo selecionado por uma política, atualizar seu estado ou migrar metadados de rótulo gravados por um fluxo de trabalho mais antigo do Microsoft Information Protection (MIP).

Aspose.Slides for Python via .NET expõe metadados de rótulo de sensibilidade modernos através de [Presentation.sensitivity_labels](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/sensitivity_labels/). Esta propriedade retorna uma [SensitivityLabelCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/) que pode ser inspecionada e modificada antes de a apresentação ser salva como PPTX.

{{% alert color="primary" title="Note" %}}

Os identificadores de rótulo de sensibilidade e as informações de política são definidos pela sua configuração do Microsoft Purview. Valide a disponibilidade de rótulos e os requisitos de política no seu ambiente antes de adicionar ou migrar metadados. Os valores de [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/content_mark_types/) descrevem as marcações de conteúdo associadas a um rótulo; eles não adicionam texto ou formas visíveis aos slides por si sós.

{{% /alert %}}

## **Entender as propriedades do rótulo de sensibilidade**

Cada [SensitivityLabel](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/) contém os seguintes metadados:

| Propriedade | Finalidade |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/id/) | Identifica o rótulo de sensibilidade na política do Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifica o site associado à política do rótulo. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Indica se o rótulo está habilitado. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/is_removed/) | Indica que o rótulo foi removido. Defina esta propriedade como `True` quando o estado de remoção precisar ser mantido nos metadados. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Especifica se o rótulo foi aplicado automaticamente ou por decisão do usuário. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Lista os tipos de marcação de conteúdo associados ao rótulo. |

A enumeração [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelassignmenttype/) descreve como um rótulo foi atribuído:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo padrão ou aplicado automaticamente.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo aplicado por decisão do usuário, incluindo rótulos aplicados manualmente, recomendados e mandatórios.

A enumeração [SensitivityLabelContentType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcontenttype/) identifica a marcação associada a um rótulo:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcontenttype/) | O rótulo foi aplicado por padrão ou automaticamente. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo do cabeçalho está associada ao rótulo. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo do rodapé está associada ao rótulo. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo da marca d'água está associada ao rótulo. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcontenttype/) | A proteção por criptografia está associada ao rótulo. |

Múltiplos tipos de marcação podem ser associados a um mesmo rótulo.

## **Listar rótulos de sensibilidade existentes**

Leia a coleção de rótulos modernos de [Presentation.sensitivity_labels](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/sensitivity_labels/) e enumere-a. O exemplo a seguir lista todas as propriedades e marcações de conteúdo armazenadas para cada rótulo:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Adicionar um rótulo de sensibilidade com marcação de conteúdo**

Use [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/add/) com o identificador do rótulo, o identificador do site, o estado habilitado e o método de atribuição. Passe o identificador do site como um objeto Python `uuid.UUID`. Após o método retornar o novo [SensitivityLabel](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/), anexe os valores de marcação necessários a [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

O exemplo a seguir adiciona um rótulo selecionado manualmente associado a marcações de rodapé e marca d'água e, em seguida, salva o resultado como PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Atualizar um rótulo de sensibilidade**

As propriedades de [SensitivityLabel](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/) são leitura/gravação, exceto que a lista retornada por [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/content_mark_types/) é modificada por meio de suas operações de lista. Depois de localizar o rótulo necessário, você pode atualizar seu identificador, identificador do site, estado habilitado, método de atribuição, estado de remoção e tipos de marcação de conteúdo. Salve a apresentação para persistir as alterações.

O exemplo a seguir atualiza o estado habilitado e o método de atribuição do primeiro rótulo:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Marcar um rótulo de sensibilidade como removido**

Para preservar o fato de que um rótulo foi removido, encontre o rótulo e defina [SensitivityLabel.is_removed](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/is_removed/) como `True`. Isso mantém a entrada do rótulo enquanto registra seu estado removido. Se, ao contrário, precisar excluir uma entrada da coleção moderna, use [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/clear/) para excluir todas as entradas.

O exemplo a seguir marca um rótulo específico como removido e salva a apresentação atualizada:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Ler e migrar rótulos de sensibilidade legados do MIP**

Fluxos de trabalho mais antigos baseados em MIP podem armazenar metadados de rótulo de sensibilidade em propriedades de documento personalizadas em vez da coleção de rótulos moderna. Leia esses metadados com [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). O método analisa as propriedades personalizadas legadas e retorna objetos [SensitivityLabel](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/).

Para migrar os metadados, adicione cada rótulo retornado à moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/) através de [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/add/). Como a adição de um identificador de rótulo duplicado gera uma exceção, o exemplo verifica a coleção de destino antes de copiar cada rótulo. Você pode acrescentar validações adicionais para confirmar que cada rótulo legado ainda existe na política atual do Purview.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

A migração copia os objetos de rótulo analisados para a coleção moderna. Não é necessário limpar todas as propriedades de documento personalizadas, portanto os metadados de documento não relacionados permanecem intactos. Use [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) com [SaveFormat.PPTX](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/) para gravar os metadados de rótulo modernos em um arquivo PPTX.

## **FAQ**

**Adicionar um tipo de marcação de conteúdo cria um cabeçalho, rodapé ou marca d'água visível nos slides?**

Não. Os valores adicionados através de [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/content_mark_types/) descrevem as marcações associadas ao rótulo de sensibilidade. Eles não criam texto ou formas visíveis na apresentação. Adicione o conteúdo de slide correspondente separadamente se o seu fluxo de trabalho precisar renderizar essas marcações.

**Qual a diferença entre marcar um rótulo como removido e excluí‑lo da coleção?**

Definir [SensitivityLabel.is_removed](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/is_removed/) como `True` mantém a entrada do rótulo e registra seu estado removido. Chamar [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) exclui a entrada da coleção moderna. Escolha a operação que corresponde aos requisitos de retenção de metadados da sua organização.

**Uma apresentação pode conter metadados legados do MIP e rótulos de sensibilidade modernos ao mesmo tempo?**

Sim. Rótulos legados podem permanecer nas propriedades de documento personalizadas enquanto rótulos modernos ficam disponíveis através de [Presentation.sensitivity_labels](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/sensitivity_labels/). Use [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) para ler os metadados legados e migrar somente os rótulos válidos que ainda não estão presentes na coleção moderna.

**O que acontece quando um rótulo com o mesmo identificador é adicionado mais de uma vez?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabelcollection/add/) gera uma exceção quando a coleção já contém um rótulo com o mesmo identificador. Verifique os valores de [SensitivityLabel.id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sensitivitylabel/id/) existentes antes de adicionar ou migrar rótulos.

**Qual formato de saída deve ser usado para preservar os rótulos de sensibilidade atualizados?**

Salve a apresentação como PPTX chamando [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) com [SaveFormat.PPTX](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/), conforme demonstrado nos exemplos acima.