---
title: Gerenciar rótulos de sensibilidade em apresentações PowerPoint em Python
linktitle: Rótulos de Sensibilidade
type: docs
weight: 50
url: /pt/python-java/sensitivity-labels/
keywords:
- rótulo de sensibilidade
- Microsoft Purview
- Microsoft Information Protection
- metadados MIP
- marcação de conteúdo
- proteção de informações
- governança de documentos
- PowerPoint
- PPTX
- segurança de apresentação
- Python
- Aspose.Slides
description: "Leia, adicione, atualize, remova e migre rótulos de sensibilidade do Microsoft Purview em apresentações PPTX do PowerPoint com Aspose.Slides para Python via Java."
---
## **Visão geral**

Microsoft Purview sensitivity labels ajudam as organizações a classificar e governar documentos. Durante o processamento automático de apresentações, um aplicativo pode precisar preservar um rótulo existente, aplicar um rótulo selecionado por uma política, atualizar seu estado ou migrar metadados de rótulo gravados por um fluxo de trabalho mais antigo do Microsoft Information Protection (MIP).

Aspose.Slides expõe metadados modernos de rótulos de sensibilidade por meio de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSensitivityLabels). Esse método retorna uma [SensitivityLabelCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/) que pode ser inspecionada e modificada antes de a apresentação ser salva como PPTX.

{{% alert color="info" title="Nota" %}}

Os identificadores de rótulo de sensibilidade e as informações de política são definidos pela sua configuração do Microsoft Purview. Valide a disponibilidade de rótulos e os requisitos de política no seu ambiente antes de adicionar ou migrar metadados. Os valores de [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrevem as marcações de conteúdo associadas a um rótulo; eles não adicionam texto ou formas visíveis aos slides por si só.

{{% /alert %}}

## **Entenda as propriedades do rótulo de sensibilidade**

Cada [SensitivityLabel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/) contém os seguintes metadados:

| Métodos | Propósito |
| --- | --- |
| [getId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getId) and [setId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#setId) | Obter ou definir o identificador do rótulo de sensibilidade na política do Purview. |
| [getSiteId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getSiteId) and [setSiteId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Obter ou definir o site associado à política do rótulo. |
| [isEnabled](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#isEnabled) and [setEnabled](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Obter ou definir se o rótulo está habilitado. |
| [isRemoved](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#isRemoved) and [setRemoved](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Obter ou definir se o rótulo foi removido. Defina o valor como `True` quando o estado de remoção precisar ser mantido nos metadados. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [setAssignmentMethodType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obter ou definir se o rótulo foi aplicado automaticamente ou por decisão do usuário. |
| [getContentMarkTypes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obter os tipos de marcação de conteúdo associados ao rótulo. |

A classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelassignmenttype/) define como um rótulo foi atribuído:

- [Standard](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo padrão ou aplicado automaticamente.
- [Privileged](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo aplicado por decisão do usuário, incluindo rótulos aplicados manualmente, recomendados e obrigatórios.

A classe [SensitivityLabelContentType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcontenttype/) define a marcação associada a um rótulo:

| Valor | Significado |
| --- | --- |
| [None](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcontenttype/) | O rótulo foi aplicado por padrão ou automaticamente. |
| [Header](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de cabeçalho está associada ao rótulo. |
| [Footer](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de rodapé está associada ao rótulo. |
| [Watermark](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de marca d'água está associada ao rótulo. |
| [Encryption](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcontenttype/) | A proteção por criptografia está associada ao rótulo. |

Vários tipos de marcação podem ser associados a um rótulo.

## **Listar rótulos de sensibilidade existentes**

Leia a coleção de rótulos modernos de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSensitivityLabels) e enumere-a. O exemplo a seguir lista cada propriedade e marcação de conteúdo armazenada para cada rótulo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Adicionar um rótulo de sensibilidade com marcação de conteúdo**

Use [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/#add) com o identificador do rótulo, identificador do site, estado habilitado e método de atribuição. Após o método retornar o novo [SensitivityLabel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/), adicione os valores de marcação requeridos através da lista retornada por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

O exemplo a seguir adiciona um rótulo selecionado manualmente associado a marcações de rodapé e marca d'água e, em seguida, salva o resultado como PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atualizar um rótulo de sensibilidade**

Os valores de [SensitivityLabel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/) são leitura/gravação, exceto que a lista retornada por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) é modificada por suas operações de lista. Depois de localizar o rótulo necessário, você pode atualizar seu identificador, identificador do site, estado habilitado, método de atribuição, estado de remoção e tipos de marcação de conteúdo. Salve a apresentação para persistir as alterações.

O exemplo a seguir atualiza o estado habilitado e o método de atribuição do primeiro rótulo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Marcar um rótulo de sensibilidade como removido**

Para preservar o fato de que um rótulo foi removido, encontre o rótulo e chame [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#setRemoved) com `True`. Isso mantém a entrada do rótulo enquanto registra seu estado removido. Se, ao contrário, precisar excluir uma entrada da coleção moderna, use [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/#clear) para excluir todas as entradas.

O exemplo a seguir marca um rótulo específico como removido e salva a apresentação atualizada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ler e migrar rótulos de sensibilidade legados do MIP**

Fluxos de trabalho baseados em MIP mais antigos podem armazenar metadados de rótulos de sensibilidade em propriedades de documento personalizadas em vez da coleção de rótulos moderna. Leia esses metadados com [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getSensitivityLabels). O método analisa as propriedades personalizadas legadas e devolve um array de objetos [SensitivityLabel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/).

Para migrar os metadados, adicione cada rótulo retornado à [SensitivityLabelCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/) moderna por meio de [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/#add). Como adicionar um identificador de rótulo duplicado gera uma exceção, o exemplo verifica a coleção de destino antes de copiar cada rótulo. Você pode adicionar validações adicionais para confirmar que cada rótulo legado ainda existe na política atual do Purview.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A migração copia os objetos de rótulo analisados para a coleção moderna. Não é necessário limpar todas as propriedades de documento personalizadas, portanto os metadados de documento não relacionados permanecem intactos. Use [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/) para gravar os metadados de rótulo modernos em um arquivo PPTX.

## **FAQ**

**Adicionar um tipo de marcação de conteúdo cria um cabeçalho, rodapé ou marca d'água visível nos slides?**

Não. Os valores adicionados através da lista retornada por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrevem as marcações associadas ao rótulo de sensibilidade. Eles não criam texto ou formas visíveis na apresentação. Adicione o conteúdo de slide correspondente separadamente se o seu fluxo de trabalho precisar renderizar essas marcações.

**Qual é a diferença entre marcar um rótulo como removido e excluí-lo da coleção?**

Chamar [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#setRemoved) com `True` mantém a entrada do rótulo e registra seu estado removido. Chamar [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) exclui a entrada da coleção moderna. Escolha a operação que corresponde aos requisitos de retenção de metadados da sua organização.

**Uma apresentação pode conter metadados legados do MIP e rótulos de sensibilidade modernos simultaneamente?**

Sim. Rótulos legados podem permanecer em propriedades de documento personalizadas enquanto rótulos modernos ficam disponíveis através de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSensitivityLabels). Use [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getSensitivityLabels) para ler os metadados legados e migrar somente os rótulos válidos que ainda não estejam presentes na coleção moderna.

**O que acontece quando um rótulo com o mesmo identificador é adicionado mais de uma vez?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabelcollection/#add) gera uma exceção quando a coleção já contém um rótulo com o mesmo identificador. Verifique os valores existentes retornados por [SensitivityLabel.getId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sensitivitylabel/#getId) antes de adicionar ou migrar rótulos.

**Qual formato de saída deve ser usado para preservar os rótulos de sensibilidade atualizados?**

Salve a apresentação como PPTX chamando [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/), conforme mostrado nos exemplos acima.