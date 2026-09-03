---
title: Gérer les avertissements de présentation en C++
type: docs
weight: 70
url: /fr/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- rappel d'avertissement
- politique d'avertissement
- perte de données
- corruption de la source
- problème de compatibilité
- substitution de police
- signature numérique
- chargement de la présentation
- rendu de la présentation
- conversion de la présentation
- enregistrement de la présentation
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Apprenez comment collecter, classer et traiter les avertissements lors du chargement, du rendu, de la conversion et de l'enregistrement des présentations avec Aspose.Slides pour C++."
---
## **Aperçu**

Aspose.Slides peut signaler des problèmes récupérables lors du chargement, du rendu, de la conversion ou de l’enregistrement d’une présentation. Les exemples incluent des enregistrements source endommagés, du contenu qui ne peut pas être conservé, la substitution de police et les limitations d’un format cible. Un rappel d’avertissement permet à une application d’enregistrer ces conditions et de décider si l’opération en cours peut se poursuivre.

Implémentez l’interface [IWarningCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/iwarningcallback/) et examinez les méthodes [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) et [IWarningInfo::get_Description](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/iwarninginfo/get_description/) fournies via [IWarningInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/iwarninginfo/). Retournez [ReturnAction::Continue](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/returnaction/) pour accepter l’avertissement ou `ReturnAction::Abort` pour interrompre l’opération.

Utilisez [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_warningcallback/) pour les avertissements générés lors de l’ouverture d’une présentation. Les classes d’options de rendu et d’exportation héritent de [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveoptions/set_warningcallback/), qui reçoit les avertissements provenant du rendu des diapositives, de la conversion et de l’enregistrement. Comme l’avertissement lui‑même n’identifie pas l’opération de l’application, associez chaque instance de rappel à une étape d’opération lorsque vous créez un rapport combiné.

## **Avertissements et Exceptions**

Un avertissement décrit une condition dont Aspose.Slides peut se remettre si le rappel renvoie `ReturnAction::Continue`. Une exception signifie que l’opération demandée ne peut pas se terminer normalement ; les exceptions ne sont pas converties en avertissements et ne peuvent pas être gérées par une politique d’avertissement.

Retourner `ReturnAction::Abort` demande au répartiteur d’avertissements de terminer l’opération en cours en levant une exception. L’exception publique dépend de l’opération et du format de la présentation. Par exemple, le chargement peut déclencher une [PptxReadException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxreadexception/) ou une [PptReadException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptreadexception/), tandis que l’enregistrement ou l’exportation peut déclencher une [PptxException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxexception/). Gérez l’exception à la frontière de l’opération et utilisez le rapport d’avertissement pour déterminer si la politique de l’application a provoqué la terminaison au lieu de vous baser sur un sous‑type d’exception ou un message. Le rappel enregistre l’avertissement avant de renvoyer `ReturnAction::Abort`, garantissant que la raison reste disponible pour l’application.

## **Catégories d’avertissement**

L’énumération [WarningType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/warningtype/) fournit les catégories suivantes :

| Type d’avertissement | Signification | Politique typique |
| --- | --- | --- |
| `SourceFileCorruption` | La présentation source contient une corruption qui peut rendre un document enregistré dans son format original inutilisable. | Interrompre. |
| `DataLoss` | Le texte, les graphiques, les images ou d’autres données peuvent être absents après le chargement ou l’enregistrement. | Interrompre. |
| `MajorFormattingLoss` | La présentation peut perdre une mise en forme importante. | Interrompre en mode de validation stricte ; sinon enregistrer et continuer. |
| `MinorFormattingLoss` | Une différence de mise en forme limitée peut se produire. | Enregistrer à des fins de diagnostic et continuer. |
| `CompatibilityIssue` | Le résultat peut ne pas s’ouvrir ou se comporter correctement dans certaines applications ou versions antérieures. | Consigner et continuer sauf si la compatibilité est obligatoire. |
| `UnexpectedContent` | La source contient du contenu non pris en charge ou non reconnu dont l’effet n’est pas encore connu. | Enregistrer et continuer, ou traiter comme une erreur en politique stricte. |

La catégorie doit guider la décision de politique. Conservez la description de l’avertissement pour le diagnostic, mais ne vous fiez pas à sa formulation pour la logique de l’application, car le texte du message peut varier selon les scénarios d’avertissement et les versions du produit.

## **Collecter et classifier les avertissements**

L’exemple suivant utilise un rapport au niveau de l’application pour l’ensemble du pipeline de traitement. Une instance de rappel distincte étiquette les avertissements provenant du chargement, du rendu, de la conversion PDF et de l’enregistrement PPTX. La politique interrompt en cas de corruption de la source ou de perte de données, interrompt éventuellement en cas de perte de mise en forme majeure, et continue pour les autres avertissements.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Définissez `abortOnMajorFormattingLoss` à `false` lorsque les différences de mise en forme majeures sont acceptables. Les problèmes de compatibilité, la perte de mise en forme mineure et le contenu inattendu sont toujours conservés dans le rapport même lorsque l’opération continue. Étendez `WarningPolicy::GetAction` si l’application doit rejeter l’une de ces catégories.

## **Scénarios d’avertissement courants**

Les avertissements peuvent apparaître à différentes étapes d’un flux de travail :

- **Signatures numériques :** Une présentation signée peut produire un avertissement lors du chargement indiquant que sa signature sera perdue pendant le traitement. Aspose.Slides signale cette condition `DataLoss` via [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Un rappel au stade de chargement permet à l’application de rejeter le fichier ou d’accepter explicitement la perte signalée.
- **Substitution de police :** Une police indisponible peut être remplacée pendant le rendu ou l’exportation d’une diapositive. Les avertissements de substitution de police sont signalés comme `DataLoss`, de sorte que la politique stricte ci‑dessus interrompt même si l’application considérerait le remplacement visuellement acceptable. Pour observer ce comportement, utilisez une présentation d’entrée contenant du texte dans une police indisponible à l’exécution. La description de l’avertissement identifie la substitution ; configurez les polices requises ou les [règles de substitution de police](/slides/fr/cpp/font-substitution/) avant de réessayer.
- **Contenu non pris en charge ou inattendu :** Un chargeur peut rencontrer des enregistrements de présentation ou des fonctionnalités qu’il ne reconnaît pas. De tels avertissements peuvent utiliser `UnexpectedContent`, ou une catégorie plus sévère lorsque des données ou la mise en forme sont connues comme affectées.
- **Compatibilité de format :** Enregistrer dans un autre format de présentation peut omettre des fonctionnalités ou produire un résultat qui se comporte différemment dans certaines applications. Par exemple, enregistrer une présentation contenant plus de huit guides de dessin horizontaux ou verticaux dans le format PPT hérité génère un `CompatibilityIssue`. Le rappel au stade d’enregistrement peut enregistrer la perte et continuer, ou la rejeter si la préservation de tous les guides est requise.
- **Comportement de chargement :** Les options de chargement et les comportements hérités peuvent également produire des avertissements. Par exemple, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifie l’utilisation d’un comportement de verrouillage de présentation obsolète comme un `CompatibilityIssue`.

Les avertissements dépendent du document source, du format cible, de l’opération et de la version d’Aspose.Slides. Ne supposez pas que chaque fichier génère un avertissement ou qu’un scénario corresponde toujours à une seule catégorie.

## **Gérer en toute sécurité les opérations interrompues**

Lorsque un rappel renvoie `ReturnAction::Abort`, n’utilisez pas un objet qui a échoué au chargement et ne présumez pas qu’une sortie de rendu ou d’enregistrement est complète. L’opération peut se terminer après la création d’un fichier de sortie mais avant qu’il ne soit finalisé.

Enregistrez les résultats validés dans un chemin distinct tel que `validated-output.pptx`. Remplacez une présentation existante uniquement après que l’opération se soit terminée avec succès, que le rapport d’avertissement satisfasse la politique de l’application et que la sortie puisse être ouverte et vérifiée. Cela évite d’écraser un fichier source valide avec un résultat partiel ou rejeté.

Un rapport d’avertissement vide ne garantit pas que chaque fonctionnalité source a été préservée. Appliquez toutes les vérifications de contenu et visuelles supplémentaires requises par l’application. Voir également [Open Presentations](/slides/fr/cpp/open-presentation/) et [Save Presentations](/slides/fr/cpp/save-presentation/).

## **FAQ**

**Un rappel d’avertissement peut‑il gérer chaque erreur Aspose.Slides ?**

Non. Il gère les conditions récupérables signalées comme avertissements. Les exceptions qui surviennent indépendamment du rappel doivent être gérées par l’application autour de l’appel de chargement, de rendu, de conversion ou d’enregistrement.

**Le retour de `ReturnAction::Continue` garantit‑il une sortie identique ?**

Non. Il ne fait que permettre la poursuite du traitement. La condition signalée peut encore entraîner des différences de données, de mise en forme ou de compatibilité, il faut donc examiner les types et les descriptions des avertissements collectés.

**Comment une application peut‑elle identifier l’opération qui a produit un avertissement ?**

Créez une instance de rappel pour chaque opération et stockez une étape définie par l’application ainsi que le type et la description de l’avertissement, comme illustré dans l’exemple.