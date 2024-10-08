---  
title: Obtenir des rappels d'avertissement pour la substitution de polices dans Aspose.Slides  
type: docs  
weight: 70  
url: /fr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/  
---  

{{% alert color="primary" %}}  

Aspose.Slides pour C++ permet d'obtenir des rappels d'avertissement pour la substitution de polices dans le cas où la police utilisée n'est pas disponible sur une machine pendant le processus de rendu. Les rappels d'avertissement sont utiles pour résoudre les problèmes de polices manquantes ou inaccessibles pendant le processus de rendu.  

{{% /alert %}}  
## **Obtenir des rappels d'avertissement pour la substitution de polices**  
Aspose.Slides pour C++ fournit des méthodes d'API simples pour obtenir les rappels d'avertissement pendant le processus de rendu. Tout ce que vous devez faire est de suivre les étapes ci-dessous pour configurer les rappels d'avertissement de votre côté :  

1. Créez une classe de rappel personnalisée pour recevoir les rappels.  
1. Définissez les rappels d'avertissement à l'aide de la classe [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options).  
1. Chargez le fichier de présentation qui utilise une police pour le texte à l'intérieur de celle-ci et qui n'est pas disponible sur votre machine cible.  
1. Générez la miniature de la diapositive pour voir l'effet.  

``` cpp  
class HandleFontsWarnings : public Warnings::IWarningCallback  
{  
public:  
    Warnings::ReturnAction Warning(SharedPtr<Warnings::IWarningInfo> warning) override  
    {  
        if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)  
        {  
            return Warnings::ReturnAction::Continue;  
        }  

        // 1 - WarningType.DataLoss  
        Console::WriteLine(System::ObjectExt::ToString(warning->get_WarningType()));  
        // "La police sera substituée de X à Y"  
        Console::WriteLine(warning->get_Description());  

        return Warnings::ReturnAction::Continue;  
    }  
};  

void Run()  
{  
    System::String dataDir = GetDataPath();  

    // Définir les rappels d'avertissement  
    System::SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();  
    options->set_WarningCallback(System::MakeObject<HandleFontsWarnings>());  

    // Instancier la présentation  
    System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", options);  

    // Générer des miniatures de diapositives  
    for (auto slide : presentation->get_Slides())  
    {  
        System::SharedPtr<IImage> image = slide->GetImage();  
    }  
}  
```  