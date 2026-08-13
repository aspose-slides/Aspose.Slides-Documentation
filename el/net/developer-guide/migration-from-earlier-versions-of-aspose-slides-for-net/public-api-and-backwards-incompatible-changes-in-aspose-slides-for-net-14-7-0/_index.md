---
title: Δημόσιο API και Αντίστροφες Μη Συμβατές Αλλαγές στο Aspose.Slides για .NET 14.7.0
linktitle: Aspose.Slides για .NET 14.7.0
type: docs
weight: 90
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σημαντικών αλλαγών στο Aspose.Slides για .NET ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 14.7.0.

{{% /alert %}} 
## **Δημόσιες Αλλαγές API**
### **Αφαιρεμένοι Κατασκευαστές και Στοιχεία**
#### **Αφαιρεμένοι Ορισμένοι Κατασκευαστές Υποτύπου TransitionValueBase και TransitionValueFactory**
Οι κατασκευαστές ορισμένων υποτύπων του TransitionValueBase (συγκεκριμένα CornerDirectionTransition, EightDirectionTransition, EmptyTransition, InOutTransition, OptionalBlackTransition, OrientationTransition, SideDirectionTransition, SplitTransition, WheelTransition) είναι άχρηστοι στο δημόσιο API και επομένως αφαιρέθηκαν. 

Η σχετική κλάση TransitionValueFactory και η διεπαφή της ITransitionValueFactory αφαιρέθηκαν για τον ίδιο λόγο.
#### **Αφαιρεμένο το Στοιχείο SoundAction από την Καταenumeration Aspose.Slides.SlideShow.TransitionType**
Το στοιχείο SoundAction ήταν εσφαλμένο και δεν χρησιμοποιείται. Οι ρυθμίσεις ήχου ορίζονται από τις ιδιότητες SlideShowTransition.SoundMode, .Sound, .SoundLoop, .SoundIsBuiltIn, .SoundName.
### **Προστέθηκαν Κλάσεις και Διεπαφές**
#### **Προστέθηκε η Κλάση FlyThroughTransition και η Διεπαφή IFlyThroughTransition**
Η κλάση Aspose.Slides.SlideShow.FlyThroughTransition (και η διεπαφή της Aspose.Slides.SlideShow.IFlyThroughTransition) σχετίζονται με τον τύπο μετάβασης Flythrough που υποστηρίζεται από αυτήν την έκδοση.
#### **Προστέθηκε η Κλάση GlitterTransition, η Διεπαφή IGlitterTransition και η Καταenumeration TransitionPattern**
Η κλάση Aspose.Slides.SlideShow.GlitterTransition (και η διεπαφή της Aspose.Slides.SlideShow.IGlitterTransition) σχετίζονται με τον τύπο μετάβασης Glitter που υποστηρίζεται από αυτήν την έκδοση.

Η καταenumeration Aspose.Slides.SlideShow.TransitionPattern χρησιμοποιείται σε αυτήν την κλάση και καθορίζει ένα γεωμετρικό μοτίβο που τοποθετείται μαζί για να καλύψει μεγαλύτερη περιοχή.
#### **Προστέθηκε η Κλάση LeftRightDirectionTransition, η Διεπαφή ILeftRightDirectionTransition και η Καταenumeration TransitionLeftRightDirectionType**
Η κλάση Aspose.Slides.SlideShow.LeftRightDirectionTransition (και η διεπαφή της Aspose.Slides.SlideShow.ILeftRightDirectionTransition) σχετίζονται με τους τύπους μετάβασης Conveyor, Ferris, Flip, Gallery και Switch. Όλοι υποστηρίζονται από αυτήν την έκδοση.

Η καταenumeration Aspose.Slides.SlideShow.TransitionLeftRightDirectionType χρησιμοποιείται σε αυτήν την κλάση και καθορίζει μια κατεύθυνση, περιορισμένη στις τιμές left και right.
#### **Προστέθηκαν Νέα Στοιχεία στην Καταenumeration Aspose.Slides.SlideShow.TransitionType**
Η καταenumeration Aspose.Slides.SlideShow.TransitionType επεκτάθηκε με νέα στοιχεία.

- Νέα στοιχεία σχετικά με τις μεταβάσεις PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- Νέα στοιχεία σχετικά με τις νέες μεταβάσεις PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **Προστέθηκε η Κλάση RevealTransition και η Διεπαφή IRevealTransition**
Η κλάση Aspose.Slides.SlideShow.RevealTransition (και η διεπαφή της Aspose.Slides.SlideShow.IRevealTransition) σχετίζεται με τον τύπο μετάβασης Reveal που υποστηρίζεται από αυτήν την έκδοση.
#### **Προστέθηκε η Κλάση RippleTransition, η Διεπαφή IRippleTransition και η Καταenumeration TransitionCornerAndCenterDirectionType**
Η κλάση Aspose.Slides.SlideShow.RippleTransition (και η διεπαφή της Aspose.Slides.SlideShow.IRippleTransition) σχετίζεται με τον τύπο μετάβασης Ripple που υποστηρίζεται από αυτήν την έκδοση.

Η καταenumeration Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType χρησιμοποιείται σε αυτήν την κλάση και καθορίζει μια κατεύθυνση, περιορισμένη στις γωνίες και το κέντρο.