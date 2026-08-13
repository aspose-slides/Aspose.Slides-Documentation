---
title: Gerenciar rótulos de sensibilidade em apresentações PowerPoint em C++
linktitle: Rótulos de Sensibilidade
type: docs
weight: 50
url: /pt/cpp/sensitivity-labels/
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
- segurança de apresentações
- C++
- Aspose.Slides
description: "Leia, adicione, atualize, remova e migre rótulos de sensibilidade do Microsoft Purview em apresentações PowerPoint PPTX com Aspose.Slides para C++."
---
## **Visão geral**

Microsoft Purview sensitivity labels ajudam as organizações a classificar e governar documentos. Durante o processamento automático de apresentações, um aplicativo pode precisar preservar um rótulo existente, aplicar um rótulo selecionado por uma política, atualizar seu estado ou migrar metadados de rótulo escritos por um fluxo de trabalho antigo do Microsoft Information Protection (MIP).

Aspose.Slides expõe metadados modernos de rótulo de sensibilidade por meio de [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Esse método retorna uma [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/) que pode ser inspecionada e modificada antes de a apresentação ser salva como PPTX.

{{% alert color="info" title="Nota" %}}
Os identificadores de rótulo de sensibilidade e as informações de política são definidos pela sua configuração do Microsoft Purview. Valide a disponibilidade de rótulos e os requisitos de política no seu ambiente antes de adicionar ou migrar metadados. Os valores de [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) descrevem as marcações de conteúdo associadas a um rótulo; eles não criam texto ou formas visíveis nos slides.
{{% /alert %}}

## **Compreender propriedades do rótulo de sensibilidade**

Cada [ISensitivityLabel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/) contém os seguintes metadados:

| Acessadores | Finalidade |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/set_id/) | Identifica o rótulo de sensibilidade na política do Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identifica o site associado à política do rótulo. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Indica se o rótulo está habilitado. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Indica que o rótulo foi removido. Defina o valor como `true` quando o estado de remoção precisar ser mantido nos metadados. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Especifica se o rótulo foi aplicado automaticamente ou por decisão do usuário. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Lista os tipos de marcação de conteúdo associados ao rótulo. |

A enumeração [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelassignmenttype/) descreve como um rótulo foi atribuído:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo padrão ou aplicado automaticamente.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo aplicado por decisão do usuário, incluindo rótulos aplicados manualmente, recomendados e mandatórios.

A enumeração [SensitivityLabelContentType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelcontenttype/) identifica a marcação associada a um rótulo:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelcontenttype/) | O rótulo foi aplicado por padrão ou automaticamente. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelcontenttype/) | Uma marcação de conteúdo de cabeçalho está associada ao rótulo. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelcontenttype/) | Uma marcação de conteúdo de rodapé está associada ao rótulo. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelcontenttype/) | Uma marcação de conteúdo de marca‑d’água está associada ao rótulo. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sensitivitylabelcontenttype/) | Uma proteção de criptografia está associada ao rótulo. |

Vários tipos de marcação podem ser associados a um único rótulo.

## **Listar rótulos de sensibilidade existentes**

Leia a coleção de rótulos modernos de [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) e enumerá‑la. O exemplo a seguir lista todas as propriedades e marcações de conteúdo armazenadas para cada rótulo:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Adicionar um rótulo de sensibilidade com marcação de conteúdo**

Use [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/add/) com o identificador do rótulo, identificador do site, estado habilitado e método de atribuição. Após o método retornar o novo [ISensitivityLabel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/), adicione os valores de marcação necessários via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

O exemplo a seguir adiciona um rótulo selecionado manualmente associado a marcações de rodapé e marca‑d’água e, em seguida, salva o resultado como PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Atualizar um rótulo de sensibilidade**

Os valores de [ISensitivityLabel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/) são leitura/escrita através de seus métodos getter e setter, exceto a coleção retornada por [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) que é modificada por suas operações de lista. Após localizar o rótulo necessário, você pode atualizar seu identificador, identificador do site, estado habilitado, método de atribuição, estado de remoção e tipos de marcação de conteúdo. Salve a apresentação para persistir as alterações.

O exemplo a seguir atualiza o estado habilitado e o método de atribuição do primeiro rótulo:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Marcar um rótulo de sensibilidade como removido**

Para preservar o fato de que um rótulo foi removido, encontre o rótulo e chame [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/set_isremoved/) com `true`. Isso mantém a entrada do rótulo enquanto registra seu estado removido. Se, ao contrário, precisar excluir uma entrada da coleção moderna, use [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/removeat/); use [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/clear/) para excluir todas as entradas.

O exemplo a seguir marca um rótulo específico como removido e salva a apresentação atualizada:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ler e migrar rótulos de sensibilidade legados do MIP**

Fluxos de trabalho antigos baseados em MIP podem armazenar metadados de rótulo de sensibilidade em propriedades de documento personalizadas em vez da coleção de rótulos moderna. Leia esses metadados com [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). O método analisa as propriedades personalizadas legadas e devolve um array de objetos [ISensitivityLabel](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/).

Para migrar os metadados, adicione cada rótulo retornado à [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/) moderna por meio de [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/add/). Como a adição de um identificador de rótulo duplicado gera uma exceção, o exemplo verifica a coleção de destino antes de copiar cada rótulo. Você pode adicionar validações adicionais para confirmar que cada rótulo legado ainda existe na política atual do Purview.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A migração copia os objetos de rótulo analisados para a coleção moderna. Não é necessário limpar todas as propriedades de documento personalizadas, de modo que metadados de documento não relacionados permanecem intactos. Use [IPresentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/save/) com [SaveFormat::Pptx](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/) para gravar os metadados de rótulo modernos em um arquivo PPTX.

## **Perguntas frequentes**

**Adicionar um tipo de marcação de conteúdo cria um cabeçalho, rodapé ou marca‑d’água visível nos slides?**

Não. Os valores adicionados por meio de [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) descrevem as marcações associadas ao rótulo de sensibilidade. Eles não criam texto ou formas visíveis na apresentação. Adicione o conteúdo de slide correspondente separadamente se o seu fluxo de trabalho precisar renderizar essas marcações.

**Qual a diferença entre marcar um rótulo como removido e excluí‑lo da coleção?**

Chamar [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/set_isremoved/) com `true` mantém a entrada do rótulo e registra seu estado removido. Chamar [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/removeat/) exclui a entrada da coleção moderna. Escolha a operação que corresponde aos requisitos de retenção de metadados da sua organização.

**Uma apresentação pode conter metadados legados do MIP e rótulos de sensibilidade modernos ao mesmo tempo?**

Sim. Rótulos legados podem permanecer nas propriedades de documento personalizadas enquanto os rótulos modernos ficam disponíveis através de [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Use [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) para ler os metadados legados e migrar apenas os rótulos válidos que ainda não estejam presentes na coleção moderna.

**O que acontece quando um rótulo com o mesmo identificador é adicionado mais de uma vez?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabelcollection/add/) lança uma exceção de argumento quando a coleção já contém um rótulo com o mesmo identificador. Verifique os valores existentes de [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isensitivitylabel/get_id/) antes de adicionar ou migrar rótulos.

**Qual formato de saída deve ser usado para preservar os rótulos de sensibilidade atualizados?**

Salve a apresentação como PPTX chamando [IPresentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/save/) com [SaveFormat::Pptx](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/), conforme mostrado nos exemplos acima.